using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour
{
    [SerializeField] public WingStats stats;

    Collider collider;
    Rigidbody rb;

    private void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }


    public void Equip()
    {
        collider.enabled = false;
        //rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnEquip()
    {
        collider.enabled = true;
        //rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
