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

    KeyCode WingLeftKey = KeyCode.Q;
    KeyCode WingRightKey = KeyCode.E;

    KeyCode JumpKey = KeyCode.Space;

    Vector3 desiredNextMovement = Vector3.zero;

    bool jumpInput = false;

    bool enterFlightInput = false;
    [SerializeField] float jumpActivationThresholdTime = 0.1f;
    bool jumpKeyIsBeingHeld = false;
    float currentJumpKeyHoldTime = 0f;
    
    [Header("Wings")]
    [SerializeField] float wingDropThresholdTime = 0.2f;
    float currentLeftWingKeyHoldTime = 0f; float currentRightWingKeyHoldTime = 0f;
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
        else
        {
            crowController.ReceiveIdleInput();
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
        if (Input.GetKey(WingLeftKey))
        {
            currentLeftWingKeyHoldTime += Time.deltaTime;
        }
        if (Input.GetKey(WingRightKey))
        {
            currentRightWingKeyHoldTime += Time.deltaTime;
        }

        // When they release, check how long they were being held and determine wanted usage through that
        if (Input.GetKeyUp(WingLeftKey))
        {
            if (currentLeftWingKeyHoldTime >= wingDropThresholdTime)
            { crowController.ReceiveUnequipWingInput(true); }
            else
            { crowController.ReceiveEquipWingInput(true); }

            // Reset timer
            currentLeftWingKeyHoldTime = 0f;
        }
        if (Input.GetKeyUp(WingRightKey))
        {
            if (currentLeftWingKeyHoldTime >= wingDropThresholdTime)
            { crowController.ReceiveUnequipWingInput(false); }
            else
            { crowController.ReceiveEquipWingInput(false); }

            // Reset timer
            currentRightWingKeyHoldTime = 0f;
        }

        // Check nevertheless the if Player has reached the time limit
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