using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgracaTest : MonoBehaviour {

    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    float xmin;
    float xmax;
    float ymin;
    float ymax;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjeLijevo = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, distance));
        Vector3 krajnjeDesno = Camera.main.ViewportToWorldPoint(new Vector3(0.95f,0.05f, distance));
        Vector3 krajnjeGore = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.95f, distance));
        Vector3 krajnjeDolje = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0.05f, 0.05f));
        xmin = krajnjeLijevo.x;
        xmax = krajnjeDesno.x;
        ymax = krajnjeGore.y;
        ymin = krajnjeDolje.y;

    }

    // Update is called once per frame
    void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);



        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }
}
