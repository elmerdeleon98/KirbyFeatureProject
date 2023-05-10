using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kirby : MonoBehaviour
{
    public int playerHealth = 10;
    public int playerSpeed = 5;
    public float playerJumpForce = 5f;
    public int jumpCounter = 0;

    public bool iceOn;
    public bool metalOn;
    public bool eatOn;
    public bool normalOn;
    public bool isGrounded;
    private bool isShooting = false;
    private bool isEating = false;

    public GameObject mouth, icePrefab, eatPrefab;

    private Rigidbody rigidBody;
    private PlayerInputActions playerInputActions;

    [SerializeField] private Renderer myObject;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rigidBody = GetComponent<Rigidbody>();

        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Eat.started += StartEat;
        playerInputActions.Player.Eat.canceled += StopEat;
        playerInputActions.Player.Discard.performed += Discard;
        playerInputActions.Player.Shoot.started += StartShoot;
        playerInputActions.Player.Shoot.canceled += StopShoot;

        mouth.SetActive(false);
    }

    private void Start()
    {
        myObject = GetComponent<Renderer>();
        normalOn = true;
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = playerInputActions.Player.Move.ReadValue<Vector2>();
        rigidBody.AddForce(new Vector3(moveVec.x, 0, moveVec.y) * playerSpeed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpCounter < 5)
        {
            rigidBody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
            jumpCounter++;
        }
    }

    public void StartEat(InputAction.CallbackContext eat)
    {
            isEating = true;
            StartCoroutine(kirbyEat());
    }

    public void StopEat(InputAction.CallbackContext eat)
    {
        isEating = false;
    }

    public void Discard(InputAction.CallbackContext discard)
    {
        if (discard.performed)
        {
            normalPower();
        }
    }

    public void StartShoot(InputAction.CallbackContext context)
    {
        if (iceOn==true)
        {
            isShooting = true;
            StartCoroutine(ShootIce());
        }
    }

    public void StopShoot(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private IEnumerator ShootIce()
    {
        while (isShooting)
        {
            Instantiate(icePrefab, mouth.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f); // add a delay of 0.5 seconds
        }
    }

    private IEnumerator kirbyEat()
    {
        while (isEating)
        {
            Instantiate(eatPrefab, mouth.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f); // add a delay of 0.5 seconds
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metalun")
        {
            if (normalOn == true)
            {
                playerHealth--;
            }
            if (metalOn == true)
            {
                collision.gameObject.SetActive(false);
            }

        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpCounter = 0;
        }

        if (collision.gameObject.CompareTag("Penguin"))
        {
            if (normalOn == true)
            {
                playerHealth--;
            }
            if (metalOn == true)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

    public void metalPower()
    {
        myObject.material.color = Color.gray;
        playerSpeed = 12;
        playerJumpForce = 9;
        playerHealth = 15;
        metalOn = true;
        normalOn = false;
        iceOn = false;
    }

    public void normalPower()
    {
        myObject.material.color = Color.magenta;
        playerSpeed = 35;
        playerJumpForce = 19;
        playerHealth = 10;
        metalOn = false;
        iceOn = false;
        normalOn = true;
    }

    public void icePower()
    {
        myObject.material.color = Color.blue;
        playerSpeed = 35;
        playerJumpForce = 19;
        playerHealth = 10;
        metalOn = false;
        normalOn = false;
        iceOn = true;

    }
}
