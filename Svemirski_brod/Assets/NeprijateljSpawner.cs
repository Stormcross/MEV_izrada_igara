using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeprijateljSpawner : MonoBehaviour {

    public GameObject neprijateljPrefab;

    public float sirina = 10f;
    public float visina = 5f;
    private bool movingDesno = true;
    public float brzina = 5f;
    private float xmax;
    private float xmin;
    private float ymax;
    private float ymin;



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

        foreach (Transform child in transform)
        {
            GameObject neprijatelj = Instantiate(neprijateljPrefab, child.transform.position, Quaternion.identity) as GameObject;
            neprijatelj.transform.parent = child;


        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(sirina, visina));
    }
    void Update()
    {

        if (movingDesno)
        {
            transform.position += Vector3.right * brzina * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * brzina * Time.deltaTime;
        }
        float desnaGranicaFormacije = transform.position.x + (0.5f * sirina);
        float LijevaGranicaFormacije = transform.position.x - (0.5f * sirina);

        if (LijevaGranicaFormacije < xmin)
        {
            movingDesno = true;
        }
        else if (desnaGranicaFormacije > xmax)
        {
            movingDesno = false;
        }

    }

}
