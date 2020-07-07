using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Animator anim;
    public GameObject ghostEnemy;
    public GameObject enemyParticle;

    public float swingTime;
    public float ogSwingTime = 2f;
    //private bool isSwinging;

    public AudioSource swingSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        swingTime = ogSwingTime;
        //isSwinging = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        swingSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        swingTime -= Time.deltaTime;



            if (Input.GetKeyDown(KeyCode.Return))
            {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            if (swingTime < 0)
                {
                swingTime = ogSwingTime;
                anim.SetBool("isAttacking", true);
                swingSound.Play();
            }
                else if (swingTime > 0)
                {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                    anim.SetBool("isAttacking", false);
                }
                }
            }
            else
            {
            anim.SetBool("isAttacking", false);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

            }
   
        
    }



    private void OnTriggerEnter2D(Collider2D swordHit)
    {
        if (swordHit.tag == "Ghost")
        {
            GameObject enemyExplosion = Instantiate(enemyParticle, swordHit.gameObject.transform.position, Quaternion.identity);
            Destroy(swordHit.gameObject);
            Destroy(enemyExplosion, 2f);
        }
    }
}
