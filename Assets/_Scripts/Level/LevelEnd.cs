using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject endSlides;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndSlides());
        }
    }

    private IEnumerator EndSlides()
    {
        endSlides.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TitleScreen");

    }
}
