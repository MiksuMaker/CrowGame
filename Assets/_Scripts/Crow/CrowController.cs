using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowController : MonoBehaviour
{
    #region Variables
    CrowMover mover;
    #endregion

    #region Setup
    private void Start()
    {
        // Get Components
        mover = GetComponent<CrowMover>();
    }
    #endregion

    #region Movement Handling
    public void ReceiveMovementInput(Vector3 moveVector)
    {
        // Relay the information to the CrowMover
        mover.Move(moveVector);
    }
    #endregion
}
