using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    private int currentHealth;
    //public AudioClip trumpSeeYa;

    public GameObject enemyParticle;
    //private Vector3 zeroVector;
    public GameObject player;
    //public static float score = 0f;
    // private Shake shake;

    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        //shake = GameObject.FindWithTag("ScreenShake").GetComponent<Shake>();

        deathSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            deathSound.Play();
            Instantiate(enemyParticle, transform.position, Quaternion.identity);
            //AudioSource trumpSeeYa = GetComponent<AudioSource>();
            //trumpSeeYa.Play();
            //score++;
            Destroy(gameObject);
            //shake.CamShake();
            //Debug.Log(score);


        }

    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.tag == "sword")
        //{
        //    currentHealth -= 1;
        //}
        //if (other.tag == "Player")
        //{
         //   player.GetComponent<Health>().takeDamage(1);
            //Instantiate(enemyParticle, transform.position, Quaternion.identity);
         //   Destroy(gameObject);
           //Destroy(enemyParticle, 2f);
        //}

    //}


    //public void HurtEnemy(int damage)
    //{
    //    currentHealth -= damage;
    //}

}
