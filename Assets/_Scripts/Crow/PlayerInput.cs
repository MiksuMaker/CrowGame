using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    CrowController crowController;
    Camera pCam;

    // Input Keys
    KeyCode ForwardKey= KeyCode.W;
    KeyCode LeftwardKey= KeyCode.A;
    KeyCode BackwardKey= KeyCode.S;
    KeyCode RightwardKey= KeyCode.D;

    Vector3 desiredNextMovement = Vector3.zero;

    KeyCode JumpKey = KeyCode.Space;

    bool desiredJumpInput = false;

    KeyCode WingLeftKey = KeyCode.Q;
    KeyCode WingRightKey = KeyCode.E;
    #endregion

    #region Setup
    private void Start()
    {
        // Find crowController
        crowController = FindObjectOfType<CrowController>();
        pCam = FindObjectOfType<Camera>();
    }
    #endregion
    private void Update()
    {
        // Return if no controller
        if (crowController == null) return;

        HandleMovementInput();
        HandleJumpInput();
        HandleWingInput();
    }

    // Execute the inputs
    private void FixedUpdate()
    {
        // Move
        if (desiredNextMovement != Vector3.zero)
        {
            crowController.ReceiveMovementInput(desiredNextMovement);
            desiredNextMovement = Vector3.zero;
        }
        // Jump
        if (desiredJumpInput)
        {
            crowController.ReceiveJumpInput();
            desiredJumpInput = false;
        }
    }

    #region Input Handling
    private void HandleMovementInput()
    {
        // Assemble Movement Vector --> Send it to CrowController
        Vector3 moveVector = Vector3.zero;

        // Check for Directional Inputs
        #region Directions
        if (Input.GetKey(ForwardKey)) 
        { 
            moveVector += Vector3.forward;
        }
        if (Input.GetKey(LeftwardKey)) 
        {
            moveVector += Vector3.left;
        }
        if (Input.GetKey(BackwardKey)) 
        { 
            moveVector += Vector3.back;
        }
        if (Input.GetKey(RightwardKey)) 
        { 
            moveVector += Vector3.right; 
        }
        #endregion

        // If input is not zero, send it to the Controller
        if (moveVector == Vector3.zero) return;

        desiredNextMovement = moveVector.normalized;
    }

    private void HandleJumpInput()
    {
        // Check if Jumpkey was pressed
        if (Input.GetKeyDown(JumpKey)) 
        {
            desiredJumpInput = true;
        }
    }

    private void HandleWingInput()
    {
        // Check if WingKeys were pressed
        if (Input.GetKeyDown(WingLeftKey)) 
        {

        }
        if (Input.GetKeyDown(WingRightKey))
        {

        }
    }

    #endregion
}