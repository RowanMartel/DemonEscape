using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] GameObject upgradesBtn;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == Constants.gameplaySceneIndex)
        {
            if (gameManager.Paused) Close();
            else Open();
        }
    }

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }

    public void Close()
    {
        gameManager.Paused = false;
        canvas.enabled = false;
    }
    public void Open()
    {
        gameManager.Paused = true;
        canvas.enabled = true;
        if (SceneManager.GetActiveScene().buildIndex == Constants.gameplaySceneIndex)
            upgradesBtn.SetActive(true);
        else upgradesBtn.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndRound()
    {
        Player player = FindObjectOfType<Player>();
        gameManager.money += player.Money;
        gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
    }
    public void QuitToTitle()
    {
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }
}