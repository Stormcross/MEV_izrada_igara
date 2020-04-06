using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public GameObject hitEffect;

    public float steta = 150;
    
    public float GetDamage()
    {
        return steta;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Instantiate(hitEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

}
