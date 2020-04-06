using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class KontaktNeprijatelja : MonoBehaviour
{

    public int Lifes;
    public Text uiText;
    private GameObject laser;


    void Start()
    {
        uiText = GameObject.Find("LivesUI").GetComponent<Text>();
    }
    void Update()
    {
        uiText.text ="Lives: #"+Lifes.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
        if (!laser)
        {
            Lifes--;
            Debug.Log("Ostalo mi: " + Lifes + " života");
            if(Lifes<0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }



}
