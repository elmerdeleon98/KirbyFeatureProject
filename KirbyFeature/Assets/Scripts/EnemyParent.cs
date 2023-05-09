using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public GameObject leftPoint, rightPoint, iceCubePrefab;
    private Vector3 leftPos, rightPos;
    public int enemySpeed;
    public bool goingLeft;
    public bool isFrozen;

    public int enemyHealth;

    private GameObject iceCube;

    public void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("iceAttack") && !isFrozen && iceCube == null)
        {
            isFrozen = true;
            iceCube = Instantiate(iceCubePrefab, transform.position, Quaternion.identity);
            StartCoroutine(Frozen());
        }
    }

    private IEnumerator Frozen()
    {
        yield return new WaitForSeconds(3);
        isFrozen = false;
        Destroy(iceCube);
        iceCube = null;
    }
}