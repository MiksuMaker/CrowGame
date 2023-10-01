using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MoveType")]
public class MoveType : ScriptableObject
{
    public virtual void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        // Move the Crow
        mover.rb.MovePosition(mover.transform.position 
                                += moveVector * mover.currentMoveStats.walkSpeed * Time.deltaTime);

    }
}
