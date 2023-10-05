using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/MoveTypes/Flight")]
public class MoveTypeFlight : MoveType
{
    public override void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        //// Move the Crow

        //float rotation = -moveVector.y * 0.1f;
        float rotation = moveVector.y * 0.1f;
        moveVector = new Vector3(moveVector.x, 0f, moveVector.z);


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
