using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    CrowController crowController;

    // Input Keys
    KeyCode ForwardKey= KeyCode.W;
    KeyCode LeftwardKey= KeyCode.A;
    KeyCode BackwardKey= KeyCode.S;
    KeyCode RightwardKey= KeyCode.D;

    KeyCode JumpKey = KeyCode.Space;

    KeyCode WingLeftKey = KeyCode.Q;
    KeyCode WingRightKey = KeyCode.E;
    #endregion

    #region Setup
    private void Start()
    {
        // Find crowController
        crowController = FindObjectOfType<CrowController>();
    }
    #endregion
    private void Update()
    {
        // Return if no controller
        if (crowController == null) return;

        HandleMovementInput();
        HandleMovementInput();
        HandleWingInput();
    }

    #region Input Handling
    private void HandleMovementInput()
    {

    }

    private void HandleJumpInput()
    {

    }

    private void HandleWingInput()
    {

    }

    #endregion
}