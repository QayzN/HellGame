using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //MOVEMENT

    [SerializeField]
    public float fHorizontalAcceleration = 1;
    [SerializeField]
    [Range(0, 1)]
    public float fHorizontalDampingBasic = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    public float fHorizontalDampingWhenStopping = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    public float fHorizontalDampingWhenTurning = 0.5f;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    //public float groundingForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    public float extraJumpForce;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;




    //TIMER

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    private bool timerOn;


    public float currentToHighScore;
    public float topHighScore;
    //HIGHSCORE TIMER

    public TextMeshProUGUI highScoreText;


    //HEALTH

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool loseHealth;

    public GameObject playerDamageParticle;



    public Animator blackFade;
    public Image blackFadeImage;


    public GameObject restartScreen;
    public GameObject resumeScreen;
    public GameObject winScreen;


    public ParticleSystem winParticles;

    private bool isColliding;


    //ENEMY

    public Rigidbody2D enemyRB;


    //BUTTON

    public Button resumeButton;



    //GHOSTSPAWNER THING
    public GameObject ghostSpawner;



    //AUDIO

    //public AudioSource ouchSound;
    //public AudioSource levelMusic;

    //fJumpTime was a furitless endeavor of fruitility, basically i just want to be able to jump as the character a second after he falls off the platform, because game feels icky otherwise
    //public float fJumpTime;
    //public float fJumpTimeValue = .1f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;


        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        //fJumpTime = fJumpTimeValue;

        // Starts the timer automatically
        timerIsRunning = true;
        timerOn = true;

       

        //ENEMY
        enemyRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        //BUTTON
        Button rsmButton = resumeButton.GetComponent<Button>();
        rsmButton.onClick.AddListener(TaskOnClick);

        //AUDIO

        //ouchSound = GetComponent<AudioSource>();

        //levelMusic = GetComponent<AudioSource>();
        //levelMusic.Play();

        //HIGHSCORE TEXT
        currentToHighScore = 0;
        highScoreText.text = PlayerPrefs.GetString("HighScore", "00:00:000");
        PlayerPrefs.SetFloat("isThisHighScore", currentToHighScore);
    }

    void TaskOnClick()
    {
        timerOn = true;
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
    }

    void Update()
    {


        isColliding = false;


        //MOVEMENT

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //fJumpTime = fJumpTimeValue;
        }
        //else if (isGrounded == false)
        //{
        //    while (fJumpTime > 0)
        //    {
        //        fJumpTime -= (1* Time.deltaTime);
        //   }
        //}
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //if (isGrounded == false && fJumpTime > 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        //{
        //   isJumping = true;
        //    jumpTimeCounter = jumpTime;
        //    rb.velocity = Vector2.up * jumpForce;
        //}
        //else if (isGrounded == false && fJumpTime <= 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        //{
        //    isJumping = true;
        //}
        if (isGrounded == true && (Input.GetKey(KeyCode.W) || Input.GetKey("space")))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            //fJumpTime = 0;

        }
        //implemented for testing, maybe flying carpet deal, other than that no go. to turn on, uncomment grounding force, and this script
        //if (Input.GetKey(KeyCode.S))  
        //{
        //    rb.velocity = Vector2.down * groundingForce;
        //}

        if ((Input.GetKey(KeyCode.W) || Input.GetKey("space"))&& isJumping == true)
        {
            //fJumpTime = 0;
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
           // else
           // {
            //    isJumping = false;
           // }    
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("space")) && extraJumps > 0)
        {
            //fJumpTime = 0;
            rb.velocity = Vector2.up * extraJumpForce;
            extraJumps = extraJumps - 1;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey("space"))
                {
                    isJumping = false;
                }



        //TIMER
    
        timeRemaining += Time.deltaTime;
        DisplayTime(timeRemaining);


        //HEALTH

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            //SceneManager.LoadScene("DeathScreen");
            //StartCoroutine(Fade());

            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //enemyRB.constraints = RigidbodyConstraints2D.FreezeAll;
            Time.timeScale = 0;
            restartScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //levelMusic.Pause();
            Time.timeScale = 0;
            resumeScreen.SetActive(true);
        }

        //IEnumerator Fade()
        //{
        //    blackFade.SetBool("Fade", true);
        //    yield return new WaitUntil(() => blackFadeImage.color.a == 1);
        //    SceneManager.LoadSceneAsync("DeathScreen");
        //}

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grim")
        {
            if (isColliding) return;
            isColliding = true;
            timerOn = false;
            ParticleSystem winExplosion = Instantiate(winParticles, gameObject.transform.position, transform.rotation);
            Destroy(winExplosion, 10);
            winScreen.SetActive(true);
            ghostSpawner.GetComponent<GhostSpawner>().stopSpawning();
            Time.timeScale = 0.2f;
            //levelMusic.Stop();
        }
        if (col.tag == "Health Pickup")
        {
            if (isColliding) return;
            isColliding = true;
            Destroy(col.gameObject);
            health = health + 1;
        }

        if (col.tag == "Ghost")
        {
            if (isColliding) return;
            isColliding = true;
            health = health - 1;
            Destroy(col.gameObject);
            GameObject playerDamExplosion = Instantiate(playerDamageParticle, transform.position, transform.rotation);
            Destroy(playerDamExplosion, 4f);
            //(playerDamageParticle, 2f);
           //ouchSound.Play();

        }
    }

    //HEALTH
    public void takeDamage(int damage)
    {
        health = health - 1;
    }

    //TIMER
    public void DisplayTime(float timeToDisplay)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timerOn = false;
        }


        timeToDisplay += 1;

        if (health > 0)
        {
        if (timerOn == true)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt((timeToDisplay % 60) - 2);
            float milliSeconds = (timeToDisplay % 1) * 1000;

            timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
            //currentToHighScore += Time.deltaTime;

        }
        }
        //if (currentToHighScore > PlayerPrefs.GetFloat("isThisHighScore"))
        //{
        //    PlayerPrefs.SetFloat("isThisHighScore", currentToHighScore);
        //    PlayerPrefs.SetString("HighScore", highScoreText.text);
        //}
        //else
        //{
        //    PlayerPrefs.SetString("HighScore", highScoreText.text);
        //}
    }


}
