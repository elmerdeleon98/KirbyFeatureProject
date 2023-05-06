/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum powerType
{
    singleShot,
    doubleShot,
    shield
}

public class Player : MonoBehaviour
{
    public Fire shotPreFab;
    public GameObject shield;
    public int playerHealth = 5;
    public Fire doubleshot;
    private powerType shooter;
    private PlayerInputActions fire;
    private InputAction shoot;
    public Text livesText;
    Vector3 myVector = Vector2.zero;
    Vector3 screenBound;

    private void Awake()
    {
        shooter = powerType.singleShot;
        fire = new PlayerInputActions();
    }

    private void FixedUpdate()
    {
        //destroys bullet if out of screen
        if (shotPreFab.gameObject.transform.position.y == 9.7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        //Will stop player from going out of screen bounds
        Vector3 screenRes = Camera.main.WorldToViewportPoint(transform.position);
        screenRes.x = Mathf.Clamp01(screenRes.x);
        screenRes.y = Mathf.Clamp01(screenRes.y);
        transform.position = Camera.main.ViewportToWorldPoint(screenRes);
        //updates lives ui
        livesText.text = "LIVES:" + playerHealth.ToString();
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnEnable()
    {
        shoot = fire.Player.Shoot;
        shoot.Enable();
        shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        shoot.Disable();
    }
    
    public void Shoot(InputAction.CallbackContext context)
    {
        //will switch between powers
        switch (shooter)
        {
            case powerType.singleShot:
                Instantiate(shotPreFab, this.transform.position, Quaternion.identity);
                break;
            case powerType.doubleShot:
                Instantiate(doubleshot, this.transform.position, Quaternion.identity);
                break;
            case powerType.shield:
                shield.gameObject.SetActive(true);
                shooter = powerType.singleShot;
                break;
            default:
                break;
        }
    }
    
    public void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.tag == "SphereEnemy")
        {
            playerHealth--;
        }
        if (collison.gameObject.tag == "CylinderEnemy")
        {
            playerHealth -= 2;
        }
        if (collison.gameObject.tag == "CubeEnemy")
        {
            playerHealth--;
        }
        if (collison.gameObject.tag == "CapsuleEnemy")
        {
            playerHealth -= 2;
        }
        if (collison.gameObject.tag == "PillEnemy")
        {
            playerHealth--;
        }
        
        if (collison.gameObject.name == "DoubleShotPowerUp(Clone)")
        {
            if (shooter == powerType.singleShot)
            {
                shooter = powerType.doubleShot;
            }
            if (shooter == powerType.doubleShot)
            {
                shooter = powerType.doubleShot;
            }
        
            if (shooter == powerType.shield)
            {
                shooter = powerType.doubleShot;
            }
        }
        
        if (collison.gameObject.name == "SingleShotPowerUp(Clone)")
        {
            if (shooter == powerType.singleShot)
            {
                shooter = powerType.singleShot;
            }
            if (shooter == powerType.doubleShot)
            {
                shooter = powerType.singleShot;
            }
            if (shooter == powerType.shield)
            {
                shooter = powerType.singleShot;
            }
        }

        if (collison.gameObject.name == "ShieldPowerUp(Clone)")
        {
            if (shooter == powerType.singleShot)
            {
                shooter = powerType.shield;
            }
            if (shooter == powerType.doubleShot)
            {
                shooter = powerType.shield;
            }
            if (shooter == powerType.shield)
            {
                shooter = powerType.shield;
            }
        }
    }
}
*/