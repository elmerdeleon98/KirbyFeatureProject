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
        // Finds kirby player
        Kirby = GameObject.FindGameObjectWithTag("Kirby");
    }

    private void Update()
    {
        // Moves iceatttack sideways
        direction.x = 1f;
        transform.position += direction * shotSpeed * Time.deltaTime;

        // Destroy shot if out of screen or too far from Kirby
        float distanceFromKirby = Mathf.Abs(transform.position.x - Kirby.transform.position.x);
        if (distanceFromKirby > 2.5f)
        {
            Destroy(gameObject);
        }
    }
}

