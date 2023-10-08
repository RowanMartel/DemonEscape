using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SaveFilesBtnMethod()
    {
        SceneManager.LoadScene(Constants.savesMenuSceneIndex);
    }
    public void OptionsBtnMethod()
    {

    }
    public void CloseGameBtnMethod()
    {
        Application.Quit();
    }
}