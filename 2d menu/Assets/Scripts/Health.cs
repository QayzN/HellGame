using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool loseHealth;



    void OnTriggerEnter2D(Collider2D healthSystem)
    {
        if(healthSystem.tag == "Health Pickup")
        {
            health = health+1;
            Destroy(healthSystem.gameObject);
        }

        if (healthSystem.tag == "Devil")
        {
            health = health - 1;
            Destroy(healthSystem.gameObject);
        } 



    }

    private void Update()
    {
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
    }




}
