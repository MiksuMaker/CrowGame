using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrowMover : MonoBehaviour
{
    #region Variables
    Camera pCam;
    CrowJumper jumper;
    CrowController controller;
    [HideInInspector] public CrowFlyer flyer;
    CrowGravity gravity;
    [HideInInspector]
    public CrowGraphicsController graphics;

    public MoveType baseMoveType;

    public MoveType currentMoveType;
    public MoveStats currentMoveStats;

    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public Vector3 lastMoveVector = Vector3.zero;

    private Animator crowAnimator;

    // Jumping
    //bool
    #endregion

    #region Setup
    private void Start()
    {
        pCam = FindObjectOfType<Camera>();
        jumper = GetComponent<CrowJumper>();
        gravity = GetComponent<CrowGravity>();
        graphics = GetComponentInChildren<CrowGraphicsController>();
        flyer = GetComponent<CrowFlyer>();
        controller = GetComponent<CrowController>();

        rb = GetComponent<Rigidbody>();

        crowAnimator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Functions
    public void Move(Vector3 moveVector)
    {
        // Check for MoveType
        if (currentMoveType == null) { Debug.Log("No MoveType available"); }
        if (currentMoveStats == null) { Debug.Log("No MoveStats available"); }


        // Execute Movement
        if (flyer.flying == false)
        {
            controller.RotateGraphicsTowardsMovement(moveVector);

            //enter walking animation //
            crowAnimator.SetFloat("Y", 1);

            // Store the LastMoveVector
            lastMoveVector = moveVector;

            currentMoveType.ExecuteMove(this, moveVector);
        }
       
    }

    public void MoveForwards(float turningModifier)
    {
        // Check for MoveType
        if (currentMoveType == null) { Debug.Log("No MoveType available"); }
        if (currentMoveStats == null) { Debug.Log("No MoveStats available"); }

        Vector3 usedMoveVector = new Vector3(lastMoveVector.x, turningModifier, lastMoveVector.z);

        // Execute Movement just Forwards
        currentMoveType.ExecuteMove(this, usedMoveVector);
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
            //enter jumping animation //
            crowAnimator.SetFloat("Y", 2);
        }
    }

    public void EnterFlight()
    {
        Debug.Log("Enter flight");

        lastMoveVector = graphics.transform.forward; // Force it to fly straight forwards
        currentMoveType = flyer.flyMoveType;

        flyer.UpdateFlightStats();

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        flyer.flying = true;

        //enter flying animation // 
        crowAnimator.SetFloat("Y", 3);

        gravity.ChangeGravity(gravity.DEFAULT_gravity - flyer.currentGravityModifier);

    }

    public void ExitFlight()
    {
        Debug.Log("Exiting Flight");
        currentMoveType = baseMoveType;

        flyer.flying = false;

        //exit flying animation
        crowAnimator.SetFloat("Y", 0);

        gravity.ChangeGravity(gravity.DEFAULT_gravity);
    }
    #endregion

}
