using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{


    public float spawnTime;
    public float ogSpawnTime;
    public GameObject Ghost;
    public GameObject spawnLocation;
    public GameObject enemyParticle;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = ogSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            Instantiate(Ghost, spawnLocation.transform.position, transform.rotation);
            spawnTime = ogSpawnTime;
        }
    }

    public void stopSpawning()
    {
        spawnTime = 1000f;
        var ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (var ghost in ghosts)
        {
            GameObject enemyExplosion = Instantiate(enemyParticle, Ghost.gameObject.transform.position, Quaternion.identity);
            Destroy(ghost);
            Destroy(enemyExplosion, 2f);
        }
        //Destroy(spawnLocation.gameObject);
    }

}
