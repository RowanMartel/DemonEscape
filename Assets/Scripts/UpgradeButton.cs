using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade.Upgrades upgrade;
    [Range(1, 3)] public int level;
    UpgradeScreen upgradeScreen;
    Button button;
    Sprite icon;
    [SerializeField] Image lockImg;
    [SerializeField] Image boughtImg;
    UpgradeManager upgradeManager;

    public bool locked;
    public UpgradeButton unlockThis;
    public UpgradeButton lockThis;

    public bool bought;

    void Start()
    {
        upgradeManager = Singleton.Instance.GetComponentInChildren<UpgradeManager>();
        upgradeScreen = GetComponentInParent<UpgradeScreen>();
        button = GetComponent<Button>();
        icon = GetComponent<Image>().sprite;

        button.onClick.AddListener(delegate () { OnClick(); });

        if (locked) lockImg.enabled = true;

        for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
        {
            if (UpgradeManager.upgrades[i].upgradeType == upgrade)
            {
                if (UpgradeManager.upgrades[i].upgradeNo >= level - 1)
                    Buy();
            }
        }
    }

    void OnClick()
    {
        if (locked) return;

        upgradeScreen.ShowUpgradeDetails(upgrade, level, icon, this);
    }

    public void Lock()
    {
        locked = true;
        lockImg.enabled = true;
        if (unlockThis != null) unlockThis.Lock();
    }
    public void Unlock()
    {
        locked = false;
        lockImg.enabled = false;
    }

    public void Buy()
    {
        bought = true;
        if (lockThis != null) lockThis.Lock();
        if (unlockThis != null) unlockThis.Unlock();
        boughtImg.enabled = true;
    }
    public void Sell()
    {
        bought = false;
        if (lockThis != null) lockThis.Unlock();
        if (unlockThis != null) unlockThis.Lock();
        if (unlockThis != null && unlockThis.bought) unlockThis.Sell();
        boughtImg.enabled = false;
    }
}