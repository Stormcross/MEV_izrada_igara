using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExpl : MonoBehaviour {

    void FixedUpdate()
    {
        Destroy(gameObject,1f);
    }
}
