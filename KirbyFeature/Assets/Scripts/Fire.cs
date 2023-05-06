using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector3 direction;
    private float shotSpeed = 13f;

    private void Update()
    {
        //will move the shot upwards
        direction.y = 1f;
        this.transform.position += this.direction * shotSpeed * Time.deltaTime;
        this.GetComponentInChildren<Transform>().position += this.direction * Time.deltaTime;

        //destroys shot if out of screen
        if (transform.position.y > 9.7f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider shotCollison)
    {
        if (shotCollison.gameObject.tag == "SphereEnemy")
        {
            Destroy(gameObject);
        }
        if (shotCollison.gameObject.tag == "CylinderEnemy")
        {
            Destroy(gameObject);
        }
        if (shotCollison.gameObject.tag == "CubeEnemy")
        {
            Destroy(gameObject);
        }
        if (shotCollison.gameObject.tag == "CapsuleEnemy")
        {
            Destroy(gameObject);
        }
        if (shotCollison.gameObject.tag == "PillEnemy")
        {
            Destroy(gameObject);
        }
    }
}
