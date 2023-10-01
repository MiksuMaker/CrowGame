using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowJumper : MonoBehaviour
{
    // Checks if jumping is allowed

    #region Variables
    [SerializeField] float jumpCheckRadius = 0.4f;
    [SerializeField] float jumpCheckHeight = 0.1f;

    #endregion

    #region Setup

    #endregion

    #region Functions
    public bool CheckJumpDistance()
    {
        // Check if there is a collider below
        bool legalHit = false;

        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.up * jumpCheckHeight, jumpCheckRadius);
        if (colliders.Length >= 2)
        {
            // Hit
            legalHit = true;
        }

        return legalHit;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (CheckJumpDistance())
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.2f, jumpCheckRadius);
    }
}
