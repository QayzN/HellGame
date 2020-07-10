using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTutorial : MonoBehaviour
{

    public float speedMin;
    public float speedMax;
    private float speed;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpawnerLocation").GetComponent<Transform>();
    }


    //public void followPlayer()
    //{
    //
    //}

        void Update()
    {


        speed = Random.Range(speedMin, speedMax);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


        //Debug.Log(target.position.x - transform.position.x);

        if ((target.position.x - transform.position.x) < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if ((target.position.x - transform.position.x) > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


       
    }
}
