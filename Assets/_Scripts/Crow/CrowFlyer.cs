using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFlyer : MonoBehaviour
{
    #region Variables
    CrowMover mover;
    CrowJumper jumper;
    CrowGravity gravity;

    [SerializeField] public MoveType flyMoveType;

    [Header("Wings")]
    [SerializeField] public WingStats leftWing;
    [SerializeField] public WingStats rightWing;

    [Header("Current Stats")]
    [SerializeField] public float currentFlightForwardSpeed = 0f;
    [SerializeField] public float currentTurning = 0f;
    [SerializeField] public float currentJumpBoost = 0f;
    [SerializeField] public float currentGravityModifier = 0f;

    [Header("Base stats")]
    [SerializeField] float BASE_flightFrowardSpeed = 1f;

    [HideInInspector] public bool flying = false;

    [Header("Fly Stopping")]
    [SerializeField] float stopFlyingForwardCheckLength = 0.1f;
    [SerializeField] float stopFlyingDownwardCheckLength = 0.1f;
    [SerializeField] float stopFlyingCheckRadius = 0.4f;
    #endregion

    #region Setup
    private void Start()
    {
        mover = GetComponent<CrowMover>();
        jumper = GetComponent<CrowJumper>();
        gravity = GetComponent<CrowGravity>();

        UpdateFlightStats();
    }
    #endregion

    private void FixedUpdate()
    {
        if (flying)
        {
            // Continuous flight
            mover.MoveForwards(currentTurning);

            // Check if touching the ground OR the wall
            if (CheckFlightStop() || CheckFlightStop(false))
            {
                mover.ExitFlight();
            }
        }
    }

    #region Update Stats
    [ContextMenu("Update Flight Stats")]
    public void UpdateFlightStats()
    {
        bool leftWingPresent = leftWing != null ? true : false;
        bool rightWingPresent = rightWing != null ? true : false;

        // Go through the wings and add the correct stats
        switch (leftWingPresent, rightWingPresent)
        {
            // BOTH WINGS
            case (true, true):
                currentFlightForwardSpeed = BASE_flightFrowardSpeed * leftWing.flightSpeedMultiplier * rightWing.flightSpeedMultiplier;
                currentTurning = -leftWing.turnStrength + rightWing.turnStrength;
                currentJumpBoost = leftWing.jumpBoost + rightWing.jumpBoost;
                currentGravityModifier = Mathf.Max(0f, leftWing.gravityModifier + rightWing.gravityModifier);
                break;

            // Only Left Wing
            case (true, false):

                currentFlightForwardSpeed = BASE_flightFrowardSpeed * leftWing.flightSpeedMultiplier_wo_Pair;
                currentTurning = -leftWing.turnStrength_wo_Pair;
                currentJumpBoost = leftWing.jumpBoost_wo_Pair;
                currentGravityModifier = leftWing.gravityModifier_wo_Pair;
                break;

            // Only Right Wing
            case (false, true):

                currentFlightForwardSpeed = BASE_flightFrowardSpeed * rightWing.flightSpeedMultiplier_wo_Pair;
                currentTurning = rightWing.turnStrength_wo_Pair;
                currentJumpBoost = rightWing.jumpBoost_wo_Pair;
                currentGravityModifier = rightWing.gravityModifier_wo_Pair;
                break;

            // NO WINGS
            case (false, false):
                currentFlightForwardSpeed = BASE_flightFrowardSpeed; currentTurning = 0f;
                currentJumpBoost = 0f; currentGravityModifier = 0f;
                break;
        }
    }
    #endregion

    #region Fly Stopping
    public bool CheckFlightStop(bool forward = true)
    {
        bool legalHit = false;

        Vector3 checkPos = Vector3.zero;
        if (forward)
        {
            // Do the forward check
            checkPos = mover.graphics.transform.forward * stopFlyingForwardCheckLength;
        }
        else { checkPos = -transform.up * stopFlyingDownwardCheckLength; }

        Collider[] colliders = Physics.OverlapSphere(transform.position + checkPos, stopFlyingCheckRadius);
        if (colliders.Length >= 2)
        {
            // Hit
            legalHit = true;
        }

        return legalHit;
    }
    #endregion
}
