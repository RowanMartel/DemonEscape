using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    Options options;
    GameManager gameManager;
    UpgradeManager upgradeManager;

    [SerializeField] GameObject gunUpgrades;
    [SerializeField] GameObject suitUpgrades;

    [SerializeField] GameObject infoPanel;
    [SerializeField] TMP_Text upgradeName;
    [SerializeField] TMP_Text upgradeDescription;
    [SerializeField] TMP_Text upgradeCost;
    [SerializeField] TMP_Text money;
    [SerializeField] Image upgradeIcon;
    Upgrade selectedUpgrade;

    void Start()
    {
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
        upgradeManager = Singleton.Instance.GetComponentInChildren<UpgradeManager>();
        options = Singleton.Instance.GetComponentInChildren<Options>();

        ShowGunUpgrades();
        infoPanel.SetActive(false);
    }

    public void TitleBtnMethod()
    {
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }
    public void GamePlayBtnMethod()
    {
        gameManager.LoadScene(Constants.gameplaySceneIndex);
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
        infoPanel.SetActive(true);
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

        selectedUpgrade.upgradeNo = level;
        upgradeName.text = selectedUpgrade.upgradeName[level];
        upgradeDescription.text = selectedUpgrade.description[level];
        upgradeCost.text = selectedUpgrade.cost[level].ToString() + '$';
        money.text = "Money:\n" + gameManager.money;
        upgradeIcon.sprite = icon;
    }

    public void BuyBtn()
    {
        if (selectedUpgrade == null || gameManager.money < selectedUpgrade.cost[selectedUpgrade.upgradeNo]) return;

        for (int i = 0; i < upgradeManager.upgrades.Count; i++)
        {
            if (upgradeManager.upgrades[i] == selectedUpgrade)
            {
                if (upgradeManager.upgrades[i].upgradeNo >= selectedUpgrade.upgradeNo) return;
                else
                {
                    upgradeManager.upgrades[i] = selectedUpgrade;
                    break;
                }
            }
        }

        Debug.Log("upgrade" + selectedUpgrade + "bought");

        gameManager.money -= selectedUpgrade.cost[selectedUpgrade.upgradeNo];
        money.text = "Money:\n" + gameManager.money;
        upgradeManager.upgrades.Add(selectedUpgrade);
    }
    public void SellBtn()
    {
        if (selectedUpgrade == null) return;
    }
}