using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGravity : MonoBehaviour
{
    #region Variables
    CrowMover mover;

    [SerializeField, Range(0f, 20f)] private float gravity = 0;
    [SerializeField] private float DEFAULT_gravity = 9.81f;

    #endregion

    #region Setup
    private void Start()
    {
        mover = GetComponent<CrowMover>();
        //mover.rb.useGravity = false;
        gravity = DEFAULT_gravity;
    }
    #endregion

    private void FixedUpdate()
    {
        // Apply gravity
        //mover.rb.velocity += ApplyGravity();
        mover.rb.AddForce(ApplyGravity(), ForceMode.Force);
    }

    #region Gravity Handling
    public Vector3 ApplyGravity()
    {
        return Vector3.up * -gravity;
    }

    public void ChangeGravity(float newGravity)
    {
        gravity = newGravity;
    }
    #endregion
}
