using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    CrowController crowController;

    // Input Keys
    KeyCode ForwardKey = KeyCode.W;
    KeyCode LeftwardKey = KeyCode.A;
    KeyCode BackwardKey = KeyCode.S;
    KeyCode RightwardKey = KeyCode.D;

    Vector3 desiredNextMovement = Vector3.zero;

    KeyCode JumpKey = KeyCode.Space;
    bool jumpInput = false;

    bool enterFlightInput = false;
    [SerializeField] float jumpActivationThresholdTime = 0.1f;
    bool jumpKeyIsBeingHeld = false;
    float currentJumpKeyHoldTime = 0f;

    KeyCode WingLeftKey = KeyCode.Q;
    KeyCode WingRightKey = KeyCode.E;
    #endregion

    #region Setup
    private void Start()
    {
        // Find crowController
        //crowController = FindObjectOfType<CrowController>();
        crowController = GetComponent<CrowController>();
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
        if (jumpInput)
        {
            crowController.ReceiveJumpInput();
            jumpInput = false;
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

    #region Jumping
    private void HandleJumpInput()
    {
        // Check if Jumpkey was pressed
        if (Input.GetKeyDown(JumpKey))
        {
            // Do Jump
            jumpInput = true;
            // Start the timer
            jumpKeyIsBeingHeld = true;

        }

        // Check if JumpKey threshold has been passed
        if (jumpKeyIsBeingHeld)
        {
            // Count it up
            currentJumpKeyHoldTime += Time.deltaTime;

            if (currentJumpKeyHoldTime >= jumpActivationThresholdTime)
            {
                // Enter flight
                crowController.ReceiveEnterFlightInput();
                // Deactivate jump Key
                jumpKeyIsBeingHeld = false;
            }
        }
        else
        {
            currentJumpKeyHoldTime = 0f;
        }

        if (Input.GetKeyUp(JumpKey))
        {
            // End the timer
            jumpKeyIsBeingHeld = false;
        }
    }

    #endregion
}