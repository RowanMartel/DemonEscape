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

    public void ShowUpgradeDetails(Upgrade.Upgrades upgrade, int level, Sprite icon, UpgradeButton upgradeButton)
    {
        selectedBtn = upgradeButton;
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
        }

        selectedUpgrade.upgradeNo = level;
        upgradeName.text = selectedUpgrade.upgradeName[level];
        upgradeDescription.text = selectedUpgrade.description[level];
        upgradeCost.text = selectedUpgrade.cost[level].ToString() + '$';
        money.text = "Money:\n" + GameManager.money;
        upgradeIcon.sprite = icon;
    }// set up the upgrade details UI

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
        money.text = "Money:\n" + GameManager.money;
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
            GameManager.money += selectedUpgrade.cost[selectedUpgrade.upgradeNo + 1];
            Debug.Log("got " + selectedUpgrade.cost[selectedUpgrade.upgradeNo + 1] + " moneys");
            if (selectedBtn.unlockThis.unlockThis != null && selectedBtn.unlockThis.unlockThis.bought)
            {
                GameManager.money += selectedUpgrade.cost[selectedUpgrade.upgradeNo + 2];
                Debug.Log("got " + selectedUpgrade.cost[selectedUpgrade.upgradeNo + 2] + " moneys");
            }
        }
        money.text = "Money:\n" + GameManager.money;
        selectedBtn.Sell();
    }// logic for selling upgrades and the ones after them
}