using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsClose : MonoBehaviour
{
    public void CloseCredits()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
