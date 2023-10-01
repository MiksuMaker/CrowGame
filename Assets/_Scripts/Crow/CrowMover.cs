using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMover : MonoBehaviour
{
    #region Variables
    Camera pCam;
    CrowJumper jumper;
    CrowGravity gravity;

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
        jumper = GetComponent<CrowJumper>();
        gravity = GetComponent<CrowGravity>();
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
        currentMoveType.ExecuteMove(this, moveVector);
    }

    public void Jump()
    {
        // Check for MoveType
        if (currentMoveType == null) { Debug.Log("No MoveType available"); }
        if (currentMoveStats == null) { Debug.Log("No MoveStats available"); }

        // Execute Jumping
        if (jumper.CheckJumpDistance())
        {
            currentMoveType.ExecuteJump(this);
        }
    }
    #endregion

}