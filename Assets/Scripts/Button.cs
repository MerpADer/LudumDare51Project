using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadNewScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
