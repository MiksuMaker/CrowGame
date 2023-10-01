using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowJumper : MonoBehaviour
{
    // Checks if jumping is allowed

    #region Variables
    [SerializeField] float jumpCheckRadius = 0.5f;

    #endregion

    #region Setup

    #endregion

    #region Functions
    public bool CheckJumpDistance()
    {
        // Check if there is a collider below
        bool legalHit = false;

        //if (Physics.Raycast(transform.position, -Vector3.up, jumpCheckDistance))
        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.up * 0.2f, jumpCheckRadius);
        if (colliders.Length >= 2)
        {
            // Hit
            //Debug.DrawRay(transform.position, -Vector3.up * jumpCheckDistance, Color.green, 2f);
            legalHit = true;
        }
        Debug.Log(colliders.Length);
        //foreach (var c in colliders)
        //{
        //    if (c.transform.gameObject.layer != LayerMask.NameToLayer("Crow"))
        //    {
        //        legalHit = true;
        //        break;
        //    }
        //}

        //legalHit = Physics.CheckSphere(transform.position + -Vector3)

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
