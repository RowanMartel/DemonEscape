using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    Options options;

    void Start()
    {
        options = FindObjectOfType<Options>();
    }

    public void SaveFilesBtnMethod()
    {
        SceneManager.LoadScene(Constants.savesMenuSceneIndex);
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