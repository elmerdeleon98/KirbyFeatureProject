using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kirby : MonoBehaviour
{
    public int playerHealth = 10;
    public int playerSpeed = 5;
    public float playerJumpForce = 5f;

    public bool iceOn;
    public bool metalOn;
    public bool eatOn;
    public bool normalOn;
    public bool isGrounded;
    public GameObject mouth, icePrefab;

    private Rigidbody rigidBody;
    private PlayerInputActions playerInputActions;
    public int jumpCounter = 0;


    [SerializeField] private Renderer myObject;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rigidBody = GetComponent<Rigidbody>();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Eat.performed += Eat;
        playerInputActions.Player.Discard.performed += Discard;
        playerInputActions.Player.Shoot.performed += Shoot;
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

    public void Eat(InputAction.CallbackContext eat)
    {
        if (isActiveAndEnabled == true)
        {

        }
    }

    public void Discard(InputAction.CallbackContext discard)
    {
        if (discard.performed)
        {
            normalPower();
        }
    }

    public void Shoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {
            Instantiate(icePrefab, mouth.transform.position, Quaternion.identity);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Metalun")
        {
            if (normalOn == true)
            {
                playerHealth--;
                metalPower();
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
                icePower();
            }
            if (metalOn == true)
            {
                collision.gameObject.SetActive(false);
            }
        }

   
    }


    private void metalPower()
    {
        myObject.material.color = Color.gray;
        playerSpeed = 12;
        playerJumpForce = 9;
        playerHealth = 15;
        metalOn = true;
        normalOn = false;
        iceOn = false;
    }

    private void normalPower()
    {
        myObject.material.color = Color.magenta;
        playerSpeed = 35;
        playerJumpForce = 19;
        playerHealth = 10;
        metalOn = false;
        iceOn = false;
        normalOn = true;
    }

    private void icePower()
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
