using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool loseHealth;


    private bool isColliding;

    public GameObject playerDamageParticle;



    public Animator anim;
    public Image img;

    void OnTriggerEnter2D(Collider2D healthSystem)
    {
        if(healthSystem.tag == "Health Pickup")
        {
            if (isColliding) return;
            isColliding = true;
            Destroy(healthSystem.gameObject);
            health = health + 1;
        }

        if (healthSystem.tag == "Ghost")
        {
            if (isColliding) return;
            isColliding = true;
            health = health - 1;
            Destroy(healthSystem.gameObject);
            GameObject playerDamExplosion = Instantiate(playerDamageParticle, transform.position, transform.rotation);
            Destroy(playerDamExplosion, 4f);
            //(playerDamageParticle, 2f);
        } 
    }

    public void takeDamage(int damage)
    {
        health = health - 1;
    }

    private void Update()
    {
        isColliding = false;
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
          //  health--;
       // }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
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
            StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            anim.SetBool("Fade", true);
            yield return new WaitUntil(() => img.color.a == 1);
            SceneManager.LoadScene("DeathScreen");
        }
    }




}
