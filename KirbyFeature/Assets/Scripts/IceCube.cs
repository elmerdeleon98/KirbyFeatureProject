using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //if kirby hits it, ice cube gets destroyed 
        if (collision.gameObject.CompareTag("Kirby"))
        {
            Destroy(this.gameObject);
        }
    }
}
