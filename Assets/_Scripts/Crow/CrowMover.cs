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
        currentMoveType.ExecuteMove(this, moveVector);
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
    //private Vector3 MoveAccordingToCamera(Vector3 rawMoveVector)
    //{
    //    Vector3 resultVector = Vector3.zero;

    //    resultVector = new Vector3(pCam.transform.right.x * rawMoveVector.magnitude,
    //                               0f,
    //                               pCam.transform.forward.y * rawMoveVector.magnitude);
    //}
    #endregion
}
