using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MoveTypes/Walk_1")]
public class MoveType : ScriptableObject
{

    public virtual void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        // Move the Crow
        mover.rb.MovePosition(mover.transform.position 
                                += moveVector * mover.currentMoveStats.walkSpeed * Time.deltaTime);

    }

    public virtual void ExecuteJump(CrowMover mover)
    {
        // Jump the Crow
        //mover.rb.AddForce(Vector3.up * mover.currentMoveStats.jumpPower,
        mover.rb.AddForce(Vector3.up * (mover.currentMoveStats.jumpPower + mover.flyer.currentJumpBoost),
                                                ForceMode.VelocityChange);
    }
}
