using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prelude : MonoBehaviour
{
    [SerializeField]
    int preludeState = 0;

    [SerializeField]
    Sprite[] preludeSlides;

    [SerializeField]
    Image preludeSlideHolder;

    public void Start()
    {
        StartCoroutine(PreludeSlides());
    }

    public void Update()
    {
        preludeSlideHolder.sprite = preludeSlides[preludeState];
    }

    private IEnumerator PreludeSlides()
    {
        yield return new WaitForSeconds(5f);
        preludeState++;
        yield return new WaitForSeconds(5f);
        preludeState++;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Teemu2");

    }
}
