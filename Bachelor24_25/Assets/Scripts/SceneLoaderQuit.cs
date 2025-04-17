using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderQuit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game!");

    }
}
