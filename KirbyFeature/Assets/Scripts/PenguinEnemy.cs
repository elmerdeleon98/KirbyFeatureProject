using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinEnemy : EnemyParent
{
    private Kirby kirby;

    private void Awake()
    {
        kirby = FindObjectOfType<Kirby>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("iceAttack") && !iceCubeInstantiated)
        {
            isFrozen = true;
            iceCubeInstantiated = true;
            GameObject ice = Instantiate(iceCube, this.transform.position, Quaternion.identity);
            StartCoroutine(Frozen(ice));
        }
        else if (other.CompareTag("Kirby"))
        {
            // Disable the ice cube
            if (iceCubeInstantiated)
            {
                iceCubeInstantiated = false;
                Destroy(GameObject.FindWithTag("IceCube"));
                gameObject.SetActive(false);
            }

        }

        if (other.CompareTag("eatAttack"))
        {
            this.gameObject.SetActive(false);
            kirby.icePower();
        }
    }

    private IEnumerator Frozen(GameObject ice)
    {
        yield return new WaitForSeconds(3);
        isFrozen = false;
        iceCubeInstantiated = false;
        Destroy(ice);
    }
}
