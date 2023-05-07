using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttack : MonoBehaviour
{
    private Vector3 direction;
    private float shotSpeed = 13f;

    private GameObject Kirby;

    private void Start()
    {
        Kirby = GameObject.FindGameObjectWithTag("Kirby");
    }

    private void Update()
    {
        direction.x = 1f;
        transform.position += direction * shotSpeed * Time.deltaTime;


        float distanceFromKirby = Mathf.Abs(transform.position.x - Kirby.transform.position.x);
        if (distanceFromKirby > 2.5f)
        {
            Destroy(gameObject);
        }
    }

    
}

