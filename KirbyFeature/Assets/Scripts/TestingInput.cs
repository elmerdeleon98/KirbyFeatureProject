using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInput : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerInputActions playerInputActions;

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
        if (context.performed)
        {
            rigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            Debug.Log("Jump!:" + context.phase);
        }
    }
    /*public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        rigidBody.AddForce(new Vector3(moveVec.x,0,moveVec.y) * 5f, ForceMode.Force);
    }
    */
   
}
