using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    //number of clouds to make
    public int numClouds = 40;

    //array to hold cloud prefabs
    public GameObject[] cloudPrefabs;

    //min pos of each cloud
    public Vector3 cloudPosMin;

    //max pos of each cloud
    public Vector3 cloudPosMax;

    //min scale for each cloud
    public float cloudScaleMin;

    //max scale for each cloud
    public float cloudScaleMax;

    //speed for each cloud 
    public float cloudSpeedMult = 0.5f;

    //references for each prefab we instantiate
    public GameObject[] cloudInstances;

    //need to initialize some values
    private void Awake()
    {
        //make an array large enough to hold all cloud instances
        cloudInstances = new GameObject[numClouds];

        //find cloud spawner parent object
        GameObject container = GameObject.Find("CloudSpawner");

        //make the clouds
        //varibale to hold ref to the cloud were instantiating
        GameObject cloud;
        for (int index = 0; index < numClouds; index++)
        {
            //pick an int between 0 and numclouds.length-1
            //note Random.range will not ever turn the max number FOR INTs
            int prefabNum = Random.Range(0, cloudPrefabs.Length);

            cloud = Instantiate(cloudPrefabs[prefabNum]) as GameObject;

            //position the cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            //scale the cloud
            float scaleU = Random.value;
            float scaleValue = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            //smaller clouds (with smaller scaleU) should be near the ground (simulating depth)
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);

            //smaller clouds should also appear to be further away 
            cPos.z = 100 - 90 * scaleU;

            //apply the new alues to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = scaleValue * Vector3.one;

            cloudInstances[index] = cloud;
            cloud.transform.SetParent(container.transform);
        }
    }

    private void Update()
    {
        //itirate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            //get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;

            //move the cloud (left)
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;

            //if cloud moves too far to the left, reset it to the right
            if (cPos.x <= cloudPosMin.x)
            {
                cPos.x = cloudPosMax.x;
            }

            cloud.transform.position = cPos;
        }
    }


}
