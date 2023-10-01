using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMover : MonoBehaviour
{
    #region Variables
    Camera pCam;

    public MoveType currentMoveType;
    public MoveStats currentMoveStats;

    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public Vector3 currentMoveVector = Vector3.zero;
    
    // Jumping
    //bool
    #endregion

    #region Setup
    private void Start()
    {
        pCam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    #endregion

    #region Functions
    public void Move(Vector3 moveVector)
    {
        // Check for MoveType
        if (currentMoveType == null) { Debug.Log("No MoveType available"); }
        if (currentMoveStats == null) { Debug.Log("No MoveStats available"); }

        // Take Camera into account

        // Execute Movement
        currentMoveType.ExecuteMove(this, MoveAccordingToCamera(moveVector));
    }

    public void Jump()
    {
        // Check for MoveType
        if (currentMoveType == null) { Debug.Log("No MoveType available"); }
        if (currentMoveStats == null) { Debug.Log("No MoveStats available"); }

        // Execute Jumping
        currentMoveType.ExecuteJump(this);
    }
    #endregion

    #region Helpers
    private Vector3 MoveAccordingToCamera(Vector3 rawMoveInput)
    {
        float facing = pCam.transform.eulerAngles.y;

        Vector3 modifiedMoveInput = new Vector3(rawMoveInput.x, 0f, rawMoveInput.z);

        Vector3 turnedInputs = Quaternion.Euler(0f, facing, 0f) * modifiedMoveInput;
        Debug.Log(turnedInputs);
        return turnedInputs;
    }
    #endregion
}
