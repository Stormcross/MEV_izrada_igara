using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgraca : MonoBehaviour {

    public float brzina = 15.0f;
    public float brzinaOkreta = 1f;
    public GameObject projektil;

    public float brzinaProjektila;

    float xmin;
    float xmax;
    float ymin;
    float ymax;


    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjeLijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjeDesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 krajnjeGore = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 krajnjeDolje = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        xmin = krajnjeLijevo.x;
        xmax = krajnjeDesno.x;
        ymax = krajnjeGore.y;
        ymin = krajnjeDolje.y;

    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject laser = Instantiate(projektil, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, brzinaProjektila, 0);


        }

        //Rotacija player shipa
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, 0f, brzinaOkreta));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, 0f, brzinaOkreta*(-1)));
        }

        //strafe lijevo desmp A D
        if (Input.GetKey(KeyCode.A))
        {
           
                transform.position += Vector3.left*brzina* Time.deltaTime;


        }
        else if (Input.GetKey(KeyCode.D))
        {


                transform.position += Vector3.right * brzina * Time.deltaTime;
            
        }
        //gore dolje W S
        if (Input.GetKey(KeyCode.W))
        {


                transform.position += Vector3.up * brzina * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.S))
        {

                transform.position += Vector3.down * brzina * Time.deltaTime;
            
        }

        //Debug.Log("Brzina: " + brzina);

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY= Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}


