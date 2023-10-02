using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGraphicsController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    Animator animator;

    [Header("Turning")]
    [SerializeField] float rotationSpeed = 0.1f;
    float deviation = 0.01f;

    [Header("Animation")]
    [SerializeField, Range(0f, 3f)] float animationValue = 0f;
    [SerializeField, Range(0f, 3f)] float targetAnimationValue = 0f;
    [Space]
    [SerializeField] float animationChangeLerpSpeedHigher = 0.1f;
    [SerializeField] float animationChangeLerpSpeedLower = 0.02f;

    [Header("Wing placement")]
    [SerializeField] public Transform leftWingPosition;
    [SerializeField] public Transform rightWingPosition;
    #endregion

    #region Setup
    #endregion

    private void Update()
    {
        LerpAnimationValue();
    }

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
    }

    public void RotateGraphicsAtPos(Vector3 worldPos)
    {
        float r = deviation;
        Vector3 rand = new Vector3(Random.Range(-r, r), 0f, Random.Range(-r, r));

        // Rotate
        //transform.Rotate(towardsDir);
        transform.LookAt(worldPos, Vector3.up);
    }

    public void RotateGraphicsByDegrees(float rotationAmount)
    {
        transform.Rotate(Vector3.up, rotationAmount);
    }
    #endregion

    #region Animations
    private void LerpAnimationValue()
    {
        // Is it higher or lower?
        float changeSpeed = 0f;
        if (targetAnimationValue > animationValue)
        { changeSpeed = animationChangeLerpSpeedHigher; }
        else
        { changeSpeed = animationChangeLerpSpeedLower; }

        // Lerp the animation value
        animationValue = Mathf.Lerp(animationValue, targetAnimationValue, changeSpeed);

        animator.SetFloat("Y", animationValue);
    }

    public enum Mode
    {
        idle, walk, jump, fly
    }

    public void UpdateAnimation(Mode mode)
    {
        switch (mode)
        {
            case Mode.idle:
                targetAnimationValue = 0f;
                break;
            case Mode.walk:
                targetAnimationValue = 1f;
                break;
            case Mode.jump:
                targetAnimationValue = 2f;
                break;
            case Mode.fly:
                targetAnimationValue = 3f;
                break;
        }
    }
    #endregion
}
