using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInput : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerInputActions playerInputActions;
    public int jumpCounter = 0;
    public bool isGrounded;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector2 moveVec = playerInputActions.Player.Move.ReadValue<Vector2>();
        rigidBody.AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpCounter<5)
        {
            rigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            Debug.Log("Jump!:" + context.phase);
            jumpCounter++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpCounter = 0;
        }
    }

}
