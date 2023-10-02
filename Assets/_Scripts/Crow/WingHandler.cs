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
            wings.OrderBy(x => Vector3.Distance(x.transform.position, transform.position));
        }

        Debug.Log("Amount of wings: " + wings.Length);

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
        }

        // Turn off colliders etc. in wing GO
        wing.Equip();
    }

    public void TryUnEquipWing(bool leftWingSide)
    {

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
