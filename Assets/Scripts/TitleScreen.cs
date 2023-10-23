using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    Options options;
    GameManager gameManager;

    void Start()
    {
        options = FindObjectOfType<Options>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SaveFilesBtnMethod()
    {
        gameManager.LoadScene(Constants.savesMenuSceneIndex);
    }
    public void OptionsBtnMethod()
    {
        options.Open();
    }
    public void CloseGameBtnMethod()
    {
        Application.Quit();
    }
}