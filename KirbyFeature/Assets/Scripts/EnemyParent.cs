using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public GameObject leftPoint, rightPoint, iceCube;

    private Vector3 leftPos, rightPos;
    public int enemySpeed;
    public int enemyHealth;

    public bool goingLeft;
    public bool isFrozen;
    public bool iceCubeInstantiated;


    private Kirby playerK;

    public void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
        playerK = GetComponent<Kirby>();
    }

    //will move the enemies from left to right
    private void Move()
    {
        if (!isFrozen)
        {
            if (goingLeft)
            {
                if (transform.position.x <= leftPos.x)
                {
                    goingLeft = false;
                }
                else
                {
                    transform.position += Vector3.left * Time.deltaTime * enemySpeed;
                }
            }
            else
            {
                if (transform.position.x >= rightPos.x)
                {
                    goingLeft = true;
                }
                else
                {
                    transform.position += Vector3.right * Time.deltaTime * enemySpeed;
                }
            }
        }
    }

    private void Update()
    {
        Move();
    }
}
