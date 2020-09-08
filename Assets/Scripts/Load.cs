using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public void gameQuit() {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void SceneLoader(int SceneIndex)

    {
        SceneManager.LoadScene(SceneIndex);
    }

     
}
