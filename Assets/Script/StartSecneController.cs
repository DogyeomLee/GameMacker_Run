using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSecneController : MonoBehaviour
{
    public void OnstartButton_Click()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnquitButton_Click()
    {
        Application.Quit();
    }
    public void OnmenuButton_Click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
