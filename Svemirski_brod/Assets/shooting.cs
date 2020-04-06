using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;

    public float bulletForce = 20f;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
	}
    void Shoot()
    {
        GameObject bullet1= Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab1, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb1= bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2= bullet2.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }
}
