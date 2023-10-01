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


        //float rotation = moveVector.y;
        //moveVector = new Vector3(moveVector.x, 0f, moveVector.z);
        //Vector3 rotatedMoveVector = Quaternion.AngleAxis(moveVector.y, Vector3.up) * moveVector;

        // Fly Forwards
        mover.rb.MovePosition(mover.transform.position
                                //+= rotatedMoveVector * mover.flyer.currentFlightForwardSpeed * Time.deltaTime);
                                += mover.lastMoveVector * mover.flyer.currentFlightForwardSpeed * Time.deltaTime);

    }

    public virtual void ExecuteJump(CrowMover mover)
    {
        // Do Nothing
    }
}
