using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        Close();
    }

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        SceneManager.LoadScene(Constants.titleScreenSceneIndex);
    }

    public void Close()
    {
        canvas.enabled = false;
        gameManager.Paused = false;
    }
    public void Open()
    {
        canvas.enabled = true;
        gameManager.Paused = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndRound()
    {
        SceneManager.LoadScene(Constants.upgradeScreenSceneIndex);
    }
    public void QuitToTitle()
    {
        SceneManager.LoadScene(Constants.titleScreenSceneIndex);
    }
}