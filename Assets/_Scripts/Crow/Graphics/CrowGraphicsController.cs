using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGraphicsController : MonoBehaviour
{
    #region Variables
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float deviation = 0.1f;
    #endregion

    #region Setup
    #endregion

    #region Functions
    public void RotateGraphicsTowards(Vector3 towardsDir)
    {
        // Get a random deviation so that LookAt works properly
        float r = deviation;
        Vector3 rand = new Vector3(Random.Range(-r, r), 0f, Random.Range(-r, r));

        // Lerp towards
        towardsDir = Vector3.Lerp(transform.forward, towardsDir + rand, rotationSpeed);

        // Rotate
        //transform.Rotate(towardsDir);
        transform.LookAt(transform.position + towardsDir, Vector3.up);

        //transform.rotation = Quaternion.LookRotation(towardsDir + transform.position);
    }
    #endregion
}
