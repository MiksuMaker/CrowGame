using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WingHandler : MonoBehaviour
{
    #region Properties
    CrowFlyer flyer;
    CrowGraphicsController graphics;

    [Header("Wing Check")]
    [SerializeField] float wingCheckRadius = 2f;

    GameObject leftWingGO;
    GameObject rightWingGO;
    #endregion

    #region Setup
    private void Start()
    {
        flyer = GetComponent<CrowFlyer>();
        graphics = GetComponentInChildren<CrowGraphicsController>();
    }
    #endregion

    #region CheckForWings
    private void FixedUpdate()
    {
        // Check for wings
    }

    private bool CheckForWings()
    {
        var wings = Physics.OverlapSphere(transform.position, wingCheckRadius, LayerMask.GetMask("Wing"));
        if (wings.Length > 0)
        {
            return true;
        }
        return false;
    }

    private Wing CheckForClosestWing()
    {
        var wings = Physics.OverlapSphere(transform.position, wingCheckRadius, LayerMask.GetMask("Wing"));
        if (wings.Length > 1)
        {
            // Take the closest one
            wings = wings.OrderBy(x => Vector3.SqrMagnitude(x.transform.position - transform.position)).ToArray();
        }

        //Debug.Log("Amount of wings: " + wings.Length);

        return wings[0].transform.GetComponent<Wing>();
    }
    #endregion

    #region Equip Unequip Wings
    public void TryEquip(bool leftWing)
    {
        if (CheckForWings())
        {
            EquipWing(CheckForClosestWing(), leftWing);
        }
    }

    public void TryUnequipWing(bool leftWingSide)
    {
        //Debug.Log("Handler");
        if (leftWingSide)
        {
            // Check if there is left wing currently
            if (leftWingGO != null)
            {
                flyer.leftWing = null;
                leftWingGO.GetComponent<Wing>().UnEquip();
                leftWingGO.transform.parent = null;
            }
        }
        else
        {
            //Debug.Log("Right");
            // Check if there is RIGHT wing currently
            if (rightWingGO != null)
            {
                flyer.rightWing = null;
                rightWingGO.GetComponent<Wing>().UnEquip();
                rightWingGO.transform.parent = null;
            }
        }
    }
    #endregion

    #region Handle Wing Equipment
    private void EquipWing(Wing wing, bool leftWingSide)
    {
        GameObject wGO = wing.gameObject;

        if (leftWingSide)
        {
            // Set wing stats
            flyer.leftWing = wing.stats;

            // Unattach previous wing
            if (leftWingGO != null)
            {
                leftWingGO.GetComponent<Wing>().UnEquip();
                leftWingGO.transform.parent = null;
            }

            //Attach gameObject to Wings
            wGO.transform.position = graphics.leftWingPosition.position;
            wGO.transform.rotation = graphics.leftWingPosition.rotation;
            wGO.transform.parent = graphics.leftWingPosition;

            leftWingGO = wGO;
        }
        else
        {
            // Set wing stats
            flyer.rightWing = wing.stats;

            // Unattach previous wing
            if (rightWingGO != null)
            {
                rightWingGO.GetComponent<Wing>().UnEquip();
                rightWingGO.transform.parent = null;
            }

            //Attach gameObject to Wings
            wGO.transform.position = graphics.rightWingPosition.position;
            wGO.transform.rotation = graphics.rightWingPosition.rotation;
            wGO.transform.parent = graphics.rightWingPosition;

            rightWingGO = wGO;
        }

        // Turn off colliders etc. in wing GO
        wing.Equip();

        // Update flyer
        flyer.UpdateFlightStats();
    }

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (CheckForWings())
        {
            Gizmos.color = Color.white;
        }

        Gizmos.DrawWireSphere(transform.position, wingCheckRadius);
    }
}
