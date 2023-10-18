using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    Options options;

    [SerializeField] GameObject gunUpgrades;
    [SerializeField] GameObject suitUpgrades;

    void Start()
    {
        options = FindObjectOfType<Options>();
        ShowGunUpgrades();
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
        options.Open();
    }
    public void ShowGunUpgrades()
    {
        gunUpgrades.SetActive(true);
        suitUpgrades.SetActive(false);
    }
    public void ShowSuitUpgrades()
    {
        suitUpgrades.SetActive(true);
        gunUpgrades.SetActive(false);
    }

    public void ShowUpgradeDetails(Upgrade upgrade)
    {
        Debug.Log("Showing upgrade: " + upgrade.GetType().Name);
    }
}