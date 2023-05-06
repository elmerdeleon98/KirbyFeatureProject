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
    public bool isGrounded;
    public GameObject mouth;

    private Rigidbody rigidBody;
    private PlayerInputActions playerInputActions;
    public int jumpCounter = 0;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rigidBody = GetComponent<Rigidbody>();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Eat.performed += Eat;
        mouth.SetActive(false);
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
            Debug.Log("Jump!:" + context.phase);
            jumpCounter++;
        }
    }

    public void Eat(InputAction.CallbackContext eat)
    {
        mouth.SetActive(true);
        //if (collision.game
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Metalun")
        {
            playerHealth--;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpCounter = 0;
        }
    }
    
}
