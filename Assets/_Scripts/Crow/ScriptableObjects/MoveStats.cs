using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MoveStats")]
public class MoveStats : ScriptableObject
{
    public float walkSpeed;

    public float jumpPower;
}
