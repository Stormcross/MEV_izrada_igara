using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrikazRezultata : MonoBehaviour {

    public static int rezultat = 0;
    public Text myText;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        Reset();
	}
    public static void Reset()
    {
        rezultat = 0;
    }
    public void Rezultat(int Points)
    {
        Debug.Log("Rezultat");
        rezultat += Points;
        myText.text = rezultat.ToString();
    }
    public string pRez()
    {
        return rezultat.ToString();
    }
}
