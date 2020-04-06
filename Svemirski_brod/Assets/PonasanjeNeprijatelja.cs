using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonasanjeNeprijatelja : MonoBehaviour {

    public float snaga=150;
    public GameObject explosion;
    public int rezultatValue = 1;
    private PrikazRezultata prikazRezultata;
    //private Bullet bullet;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //bullet = GetComponent<Collider2D>().gameObject.GetComponent<Bullet>();

        GameObject explode = Instantiate(explosion) as GameObject;
        explode.transform.position = transform.position;
        prikazRezultata = GameObject.Find("Rezultat").GetComponent<PrikazRezultata>();
        prikazRezultata.Rezultat(rezultatValue);
        //Destroy(collision.gameObject);
        Destroy(gameObject);
        
        //Bullet missile = collider.gameObject.GetComponent<Bullet>();
        //if (bullet)
        //{
        //    Debug.Log("Pogoden Nakon IF!");

        //    bullet.Hit();
        //    snaga -= bullet.GetDamage();
        //    if(snaga<=0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }

}
