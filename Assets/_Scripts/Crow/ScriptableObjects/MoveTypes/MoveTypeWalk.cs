using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/MoveTypes/Walk_2")]
public class MoveTypeWalk : MoveType
{
    public virtual void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        // Move the Crow
        
        // Add force
        Vector3 moveForce = moveVector * mover.currentMoveStats.walkSpeed * Time.deltaTime;
        mover.rb.AddForce(moveForce);

        // Limit velocity
        //float desiredVelocity = Mathf.Min(mover.rb.velocity.magnitude, mover.currentMoveStats.MAXwalkSpeed);

        //mover.rb.velocity = mover.rb.velocity.normalized * desiredVelocity;
    }
}
