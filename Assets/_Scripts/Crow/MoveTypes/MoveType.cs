using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MoveType")]
public class MoveType : ScriptableObject
{
    public virtual void ExecuteMove(CrowMover mover, Vector3 moveVector)
    {
        // Movement Logic here

    }
}
