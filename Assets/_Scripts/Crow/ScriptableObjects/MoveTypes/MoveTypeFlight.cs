using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/MoveTypes/Flight")]
public class MoveTypeFlight : MoveType
{
    public override void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        //// Move the Crow
        //mover.rb.MovePosition(mover.transform.position
        //                        += moveVector * mover.currentMoveStats.walkSpeed * Time.deltaTime);


        float rotation = -moveVector.y * 0.1f;
        moveVector = new Vector3(moveVector.x, 0f, moveVector.z);

        //Vector3 turnChange = mover.graphics.transform.right * rotation * 0.001f;

        // Rotate graphics
        mover.graphics.RotateGraphicsByDegrees(rotation);

        // Calculate next pos
        Vector3 moveToPos = mover.transform.position
                                //+= (turnChange) +
                                += 
                                //mover.lastMoveVector * mover.flyer.currentFlightForwardSpeed * Time.deltaTime;
                                mover.graphics.transform.forward * mover.flyer.currentFlightForwardSpeed * Time.deltaTime;

        Debug.DrawRay(moveToPos, Vector3.up, Color.red, 1f);

        // Fly Forwards
        mover.rb.MovePosition(moveToPos);

    }

    public virtual void ExecuteJump(CrowMover mover)
    {
        // Do Nothing
    }
}
