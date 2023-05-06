/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public static SlingShot Instance;

    //member variable reference to the Halo
    [SerializeField]
    public GameObject launchPoint;

    public GameObject prefabProjectile;

    [SerializeField]
    private Vector3 launchPos;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private bool aimingMode;

    public float velocityMult = 4f;

    //when game starts we need to make sure we have access to the launchPoint 
    private void Awake()
    {
        Instance = this;
        Transform launchPointTransform = transform.Find("LaunchPoint");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTransform.position;
    }
    private void Update()
    {
        //if slingshot is not in aimmode, dont run this code
        if (!aimingMode) return;

        //get the current mouse position in 2d screen space 
        Vector3 mousePos2D = Input.mousePosition;

        //convert mouse pos to 3d world space
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta from the launch position to the new mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit mouseDelta to the radius of our slingshot sphere collider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move the projectuile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        //check for mouse button getting released
        if (Input.GetMouseButtonUp(0))
        {
            //left mouse button was released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

            //lets forget about the projectile (we'll make another when the OnMouseDown gets called)

            FollowCam.Instance.poi = projectile;

            projectile = null;
        }
    }
    private void OnMouseEnter()
    {
        Debug.Log("MouseEnter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("MouseExit");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        //player has pressed the mouse button while ober slingshot

        //set aimingmode to true
        aimingMode = true;

        //instantiate a projectile
        projectile = Instantiate(prefabProjectile);

        //move it to the launch point
        projectile.transform.position = launchPos;

        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
*/