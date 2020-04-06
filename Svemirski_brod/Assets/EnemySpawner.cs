using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyGOgrey;
    public GameObject EnemyGOblue;
    private GameObject anEnemy;

    float MaxSpawnRateInSeconds = 2f;

    // Use this for initialization
    void Start()
    {
        Invoke("EnemySpawn1", MaxSpawnRateInSeconds);
        //povečavaj spawn rate svakih 20 sekundi
        InvokeRepeating("PovecajSpawnRate", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawn
    void EnemySpawn1()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));  //lijevi donji kut
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  //desni gornji kut
        //stvorimo nepirjatelje
        int eBroj= Random.Range(1, 100);
        if(eBroj%2==0)
        {
        anEnemy = (GameObject)Instantiate(EnemyGOgrey);

        }
        else
        {
            anEnemy = (GameObject)Instantiate(EnemyGOblue);

        }

        int rBroj = Random.Range(1, 100);
        if (rBroj % 2 == 0)
        {
            //Debug.Log("if rBroj:" + rBroj);
            anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
        else
        {
            //Debug.Log("else rBroj:" + rBroj);

            anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), min.y);

        }

        //Kada dolazi slijedeci neprijatelj
        NextNeprijatelj();
    }


    void NextNeprijatelj()
    {
        float spawnInSeconds;
        if (MaxSpawnRateInSeconds > 1f)
        {
            //odabiremo broj izmedu 1 i maxSec
            spawnInSeconds = Random.Range(1f, MaxSpawnRateInSeconds);

        }
        else
        {
            spawnInSeconds = 0.5f;

        }
        Invoke("EnemySpawn1", spawnInSeconds);
    }

    void PovecajSpawnRate()
    {
        if (MaxSpawnRateInSeconds > 1f)
        {
            MaxSpawnRateInSeconds--;
        }
        if (MaxSpawnRateInSeconds == 1)
        {
            CancelInvoke("PovecajSpawnRate");
        }
    }
}
