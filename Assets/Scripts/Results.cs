using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        Close();
    }

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
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
        gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
    }
    public void QuitToTitle()
    {
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }
}