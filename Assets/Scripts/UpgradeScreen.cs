using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    Options options;

    void Start()
    {
        options = FindObjectOfType<Options>();
    }

    public void TitleBtnMethod()
    {
        SceneManager.LoadScene(Constants.titleScreenSceneIndex);
    }
    public void GamePlayBtnMethod()
    {
        SceneManager.LoadScene(Constants.gameplaySceneIndex);
    }
    public void OptionsBtnMethod()
    {

    }
}