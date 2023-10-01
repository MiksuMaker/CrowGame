using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowController : MonoBehaviour
{
    #region Variables
    CrowMover mover;
    CrowGraphicsController graphics;
    Camera pCam;
    #endregion

    #region Setup
    private void Start()
    {
        // Get Components
        mover = GetComponent<CrowMover>();
        pCam = FindObjectOfType<Camera>();
        graphics = GetComponentInChildren<CrowGraphicsController>();
    }
    #endregion

    #region Movement Handling
    public void ReceiveMovementInput(Vector3 moveVector)
    {
        // Adjust it
        moveVector = MoveAccordingToCamera(moveVector);

        // Rotate graphics
        //RotateGraphicsTowardsMovement(moveVector);

        // Relay the information to the CrowMover
        mover.Move(moveVector);
    }

    public void ReceiveJumpInput()
    {
        mover.Jump();
    }

    public void ReceiveEnterFlightInput()
    {
        // Enter Flight if possible
        mover.EnterFlight();
    }
    #endregion

    #region Helpers
    private Vector3 MoveAccordingToCamera(Vector3 rawMoveInput)
    {
        float facing = pCam.transform.eulerAngles.y;

        Vector3 modifiedMoveInput = new Vector3(rawMoveInput.x, 0f, rawMoveInput.z);

        Vector3 turnedInputs = Quaternion.Euler(0f, facing, 0f) * modifiedMoveInput;
        return turnedInputs;
    }

    public void RotateGraphicsTowardsMovement(Vector3 dir)
    {
        // Lerp towards movement direction
        graphics.RotateGraphicsTowards(dir);
    }
    #endregion
}
