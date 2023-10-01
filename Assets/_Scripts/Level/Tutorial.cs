using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTutorialCounter());
    }

    private IEnumerator StartTutorialCounter()
    {
        yield return new WaitForSeconds(6f);
        tutorial.SetActive(true);
        
    }
}
