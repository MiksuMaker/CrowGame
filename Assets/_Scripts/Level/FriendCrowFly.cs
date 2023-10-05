using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCrowFly : MonoBehaviour
{

   [SerializeField] private Transform[] crowWaypoints;

   [SerializeField] private float crowSpeed;
    [SerializeField]private float crowRotationSpeed;

    private int crowState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move towards waypoint
        var step = crowSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, crowWaypoints[crowState].position, step);

        //Rotate towards waypoint
        transform.rotation = Quaternion.Slerp(transform.rotation, crowWaypoints[crowState].rotation, crowRotationSpeed * Time.deltaTime);

    }
}
