using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBoss : MonoBehaviour
{
    public float speed;
    private Transform bossGhost;

    // Start is called before the first frame update
    void Start()
    {
        bossGhost = GameObject.FindGameObjectWithTag("BossGhost").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        //speed = Random.Range(speedMin, speedMax);

        transform.position = Vector2.MoveTowards(transform.position, bossGhost.position, speed * Time.deltaTime);
    }
}


