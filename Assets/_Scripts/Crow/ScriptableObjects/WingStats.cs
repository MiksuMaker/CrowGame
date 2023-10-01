using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WingStat")]
public class WingStats : ScriptableObject
{
    [Header("Flight Speed")]
    [Tooltip("How fast the crow flies forward with this")]
    public float flightSpeed = 5f;
    public float flightSpeed_wo_Pair = 1f;

    [Header("Flight Gravity")]
    [Tooltip("Gravity modifier for the wing. It will decrease gravity by that amount")]
    public float gravityModifier = -2f;
    [Tooltip("Gravity modifier for the wing, when there is no another wing equipped")]
    public float gravityModifier_wo_Pair = -1f;

    [Header("Turn Strength")]
    [Tooltip("How much the wing will turn towards left/right direction. If equal with pair, will fly straight")]
    public float turnStrength = 2f;
    public float turnStrength_wo_Pair = 3f;

    [Header("Jump Boost")]
    [Tooltip("How much boost the wing gives to the base jump")]
    public float jumpBoost = 1f;
    [Tooltip("Jump boost without another pair")]
    public float jumpBoost_wo_Pair = 0f;
}
