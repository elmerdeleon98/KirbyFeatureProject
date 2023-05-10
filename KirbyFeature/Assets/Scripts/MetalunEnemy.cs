using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalunEnemy : EnemyParent
{
    private Kirby kirby;

    private void Awake()
    {
        kirby = FindObjectOfType<Kirby>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if ice attack hits enemy and there is no icecube made, freeze enemy and make icecube
        if (other.CompareTag("iceAttack") && !iceCubeInstantiated)
        {
            isFrozen = true;
            iceCubeInstantiated = true;
            GameObject ice = Instantiate(iceCube, this.transform.position, Quaternion.identity);
            StartCoroutine(Frozen(ice));
        }
        else if (other.CompareTag("Kirby"))
        {
            // Disables the ice cube
            if (iceCubeInstantiated)
            {
                iceCubeInstantiated = false;
                Destroy(GameObject.FindWithTag("IceCube"));
                gameObject.SetActive(false);
            }

        }

        //if eat hits enemy 
        if (other.CompareTag("eatAttack"))
        {
            this.gameObject.SetActive(false);
            kirby.metalPower();
        }

    }

    //freezes enemies for 3 seconds then unfreezes 
    private IEnumerator Frozen(GameObject ice)
    {
        yield return new WaitForSeconds(3);
        isFrozen = false;
        iceCubeInstantiated = false;
        Destroy(ice);
    }
}
