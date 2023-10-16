using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    Canvas canvas;
    [SerializeField] GameObject upgradesBtn;
    [SerializeField] GameManager gameManager;

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        SceneManager.LoadScene(Constants.titleScreenSceneIndex);
    }

    public void Close()
    {
        canvas.enabled = false;
    }
    public void Open()
    {
        canvas.enabled = true;
        if (SceneManager.GetActiveScene().buildIndex == Constants.gameplaySceneIndex)
            upgradesBtn.SetActive(true);
        else upgradesBtn.SetActive(false);
    }
}