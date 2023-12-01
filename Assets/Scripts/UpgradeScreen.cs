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
    UpgradeButton selectedBtn;
    int selectedLevel = 0;
    Sprite selectedIcon;
    Upgrade.Upgrades selectedUpgradeEnum;

    Upgrade previewedUpgrade;
    UpgradeButton previewedBtn;

    UpgradeButton previousBtn;

    void Start()
    {
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
        upgradeManager = Singleton.Instance.GetComponentInChildren<UpgradeManager>();
        options = Singleton.Instance.GetComponentInChildren<Options>();

        ShowGunUpgrades();
        infoPanel.SetActive(false);
        money.text = "Money:\n$" + GameManager.money;
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

    public void ShowUpgradeDetails(Upgrade.Upgrades upgrade, int level, Sprite icon, UpgradeButton upgradeButton)
    {
        selectedUpgradeEnum = upgrade;
        selectedLevel = level;
        selectedIcon = icon;
        // data saved so ShowUpgradeDetails can be shown again after previews dissapear

        previousBtn?.togglehighlight(false);
        if (!previousBtn || previousBtn != selectedBtn)
        {
            previousBtn = selectedBtn;
        }
        // hide the highlight for the previously selected upgrade

        selectedBtn = upgradeButton;
        upgradeButton.togglehighlight(true);
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
            case Upgrade.Upgrades.rocketLauncher1:
                selectedUpgrade = new RocketLauncherUpgrade1(level);
                break;
            case Upgrade.Upgrades.rocketLauncher2:
                selectedUpgrade = new RocketLauncherUpgrade2(level);
                break;
            case Upgrade.Upgrades.machineGun1:
                selectedUpgrade = new MachineGunUpgrade1(level);
                break;
            case Upgrade.Upgrades.machineGun2:
                selectedUpgrade = new MachineGunUpgrade2(level);
                break;
            case Upgrade.Upgrades.railGun1:
                selectedUpgrade = new RailGunUpgrade1(level);
                break;
            case Upgrade.Upgrades.railGun2:
                selectedUpgrade = new RailGunUpgrade2(level);
                break;
        }

        selectedUpgrade.upgradeNo = level;
        upgradeName.text = selectedUpgrade.upgradeName[level];
        upgradeDescription.text = selectedUpgrade.description[level];
        upgradeCost.text = selectedUpgrade.cost[level].ToString() + '$';
        money.text = "Money:\n$" + GameManager.money;
        upgradeIcon.sprite = icon;
    }// set up the upgrade details UI
    public void PreviewUpgradeDetails(Upgrade.Upgrades upgrade, int level, Sprite icon, UpgradeButton upgradeButton)
    {
        previewedBtn = upgradeButton;
        infoPanel.SetActive(true);
        level--;
        switch (upgrade)
        {
            case Upgrade.Upgrades.pistol1:
                previewedUpgrade = new PistolUpgrade1(level);
                break;
            case Upgrade.Upgrades.pistol2:
                previewedUpgrade = new PistolUpgrade2(level);
                break;
            case Upgrade.Upgrades.shotgun1:
                previewedUpgrade = new ShotgunUpgrade1(level);
                break;
            case Upgrade.Upgrades.shotgun2:
                previewedUpgrade = new ShotgunUpgrade2(level);
                break;
            case Upgrade.Upgrades.rocketLauncher1:
                previewedUpgrade = new RocketLauncherUpgrade1(level);
                break;
            case Upgrade.Upgrades.rocketLauncher2:
                previewedUpgrade = new RocketLauncherUpgrade2(level);
                break;
            case Upgrade.Upgrades.machineGun1:
                previewedUpgrade = new MachineGunUpgrade1(level);
                break;
            case Upgrade.Upgrades.machineGun2:
                previewedUpgrade = new MachineGunUpgrade2(level);
                break;
            case Upgrade.Upgrades.railGun1:
                previewedUpgrade = new RailGunUpgrade1(level);
                break;
            case Upgrade.Upgrades.railGun2:
                previewedUpgrade = new RailGunUpgrade2(level);
                break;
        }

        previewedUpgrade.upgradeNo = level;
        upgradeName.text = previewedUpgrade.upgradeName[level];
        upgradeDescription.text = previewedUpgrade.description[level];
        upgradeCost.text = previewedUpgrade.cost[level].ToString() + '$';
        money.text = "Money:\n$" + GameManager.money;
        upgradeIcon.sprite = icon;
    }// set up the upgrade details UI as a preview
    public void StopPreview()
    {
        infoPanel.SetActive(false);
        if (selectedUpgrade != null)
            ShowUpgradeDetails(selectedUpgradeEnum, selectedLevel, selectedIcon, selectedBtn);
    }

    public void BuyBtn()
    {
        if (selectedUpgrade == null || GameManager.money < selectedUpgrade.cost[selectedUpgrade.upgradeNo]) return;

        for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
        {
            if (UpgradeManager.upgrades[i] == selectedUpgrade)
            {
                if (UpgradeManager.upgrades[i].upgradeNo >= selectedUpgrade.upgradeNo) return;
                else
                {
                    UpgradeManager.upgrades[i] = selectedUpgrade;
                    break;
                }
            }
        }

        GameManager.money -= selectedUpgrade.cost[selectedUpgrade.upgradeNo];
        money.text = "Money:\n$" + GameManager.money;
        UpgradeManager.upgrades.Add(selectedUpgrade);
        selectedBtn.Buy();

        FindObjectOfType<Screenshot>().CaptureScreenshot();
        FindObjectOfType<SaveLoad>().Save();
    }// logic for buying upgrades
    public void SellBtn()
    {
        if (selectedUpgrade == null) return;
        Upgrade thisUpgrade = null;
        int thisIndex = 0;
        for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
        {
            if (UpgradeManager.upgrades[i].upgradeName[0] == selectedUpgrade.upgradeName[0])
            {
                thisUpgrade = selectedUpgrade;
                thisIndex = i;
            }
        }
        if (thisUpgrade == null) return;
        else UpgradeManager.upgrades.RemoveAt(thisIndex);

        Debug.Log("got " + selectedUpgrade.cost[selectedUpgrade.upgradeNo] + " moneys");
        GameManager.money += selectedUpgrade.cost[selectedUpgrade.upgradeNo];
        if (selectedBtn.unlockThis != null && selectedBtn.unlockThis.bought)
        {
            for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
            {
                if (UpgradeManager.upgrades[i].upgradeName[0] == selectedUpgrade.upgradeName[0])
                {
                    thisUpgrade = selectedUpgrade;
                    thisIndex = i;
                }
            }
            UpgradeManager.upgrades.RemoveAt(thisIndex);
            GameManager.money += selectedUpgrade.cost[selectedUpgrade.upgradeNo + 1];
            Debug.Log("got " + selectedUpgrade.cost[selectedUpgrade.upgradeNo + 1] + " moneys");
            if (selectedBtn.unlockThis.unlockThis != null && selectedBtn.unlockThis.unlockThis.bought)
            {
                for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
                {
                    if (UpgradeManager.upgrades[i].upgradeName[0] == selectedUpgrade.upgradeName[0])
                    {
                        thisUpgrade = selectedUpgrade;
                        thisIndex = i;
                    }
                }
                UpgradeManager.upgrades.RemoveAt(thisIndex);
                GameManager.money += selectedUpgrade.cost[selectedUpgrade.upgradeNo + 2];
                Debug.Log("got " + selectedUpgrade.cost[selectedUpgrade.upgradeNo + 2] + " moneys");
            }
        }
        money.text = "Money:\n$" + GameManager.money;
        selectedBtn.Sell();
    }// logic for selling upgrades and the ones after them
}