using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] 
    private Input action;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
