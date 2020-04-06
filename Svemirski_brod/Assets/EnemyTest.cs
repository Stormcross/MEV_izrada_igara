using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

    public Transform Player;
    public float RotacijaEnemy;
    public float moveSpeed = 5f;


    private Rigidbody2D rb2D;
    private Vector2 movement;


	// Use this for initialization
	void Start () {
        rb2D = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").transform;


	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 direction = Player.position - transform.position;
        Player = GameObject.FindWithTag("Player").transform;
        Vector3 direction = Player.position - transform.position;
        //Debug.Log("Pozicija " + direction);
        float kut = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + RotacijaEnemy;
        rb2D.rotation = kut;
        direction.Normalize();
        movement = direction;

        //transform.position = Vector3.Lerp(transform.position, Player.position, Time.deltaTime * moveSpeed);

    }

    private void FixedUpdate()
    {
        MoveChar(movement);
    }

    void MoveChar(Vector2 direction)
    {
        rb2D.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
