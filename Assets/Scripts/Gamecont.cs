using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamecont : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanal;

    private void Awake()
    {
        pausePanal.SetActive(false);
    }
    public void pauseGame() {
        Time.timeScale = 0f;
        pausePanal.SetActive(true);
    }

    public void resumeGame() {
        Time.timeScale = 1f;
        pausePanal.SetActive(false);
    }

    public void SceneLoader(int SceneIndex)

    {
        SceneManager.LoadScene(SceneIndex);
    }
}
