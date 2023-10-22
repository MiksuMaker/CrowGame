using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject endSlides;
    public int levelState = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && levelState >= 2)
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
