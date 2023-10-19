using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    Options options;

    [SerializeField] GameObject gunUpgrades;
    [SerializeField] GameObject suitUpgrades;

    [SerializeField] GameObject infoPanel;
    [SerializeField] TMP_Text upgradeName;
    [SerializeField] TMP_Text upgradeDescription;
    [SerializeField] TMP_Text upgradeCost;
    [SerializeField] Image upgradeIcon;
    Upgrade selectedUpgrade;

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

    public void ShowUpgradeDetails(Upgrade.Upgrades upgrade, int level, Sprite icon)
    {
        level--;
        switch (upgrade)
        {
            case Upgrade.Upgrades.pistol1:
                selectedUpgrade = new PistolUpgrade1(level);
                break;
            case Upgrade.Upgrades.pistol2:
                selectedUpgrade = new PistolUpgrade2(level);
                break;
            case Upgrade.Upgrades.shotgun1:
                selectedUpgrade = new ShotgunUpgrade1(level);
                break;
            case Upgrade.Upgrades.shotgun2:
                selectedUpgrade = new ShotgunUpgrade2(level);
                break;
        }

        upgradeName.text = selectedUpgrade.upgradeName[level];
        upgradeDescription.text = selectedUpgrade.description[level];
        upgradeCost.text = selectedUpgrade.cost[level].ToString() + '$';
        upgradeIcon.sprite = icon;
    }
}