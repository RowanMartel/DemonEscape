using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Upgrade.Upgrades upgrade;
    [Range(1, 3)] public int level;
    UpgradeScreen upgradeScreen;
    Button button;
    Sprite icon;
    [SerializeField] Image lockImg;
    [SerializeField] Image boughtImg;
    [SerializeField] Image highlightImg;
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

        button.onClick.AddListener(delegate () { OnClick(); });// adds an onclick event without the inspector

        if (locked) lockImg.enabled = true;

        for (int i = 0; i < UpgradeManager.upgrades.Count; i++)
        {
            if (UpgradeManager.upgrades[i].upgradeType == upgrade)
            {
                if (UpgradeManager.upgrades[i].upgradeNo >= level - 1)
                    Buy();
            }
        }// marks upgrade as already bought if in the upgradeManager bought list
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (locked) return;

        upgradeScreen.PreviewUpgradeDetails(upgrade, level, icon, this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (locked) return;

        upgradeScreen.StopPreview();
    }

    void OnClick()
    {
        if (locked) return;

        upgradeScreen.ShowUpgradeDetails(upgrade, level, icon, this);
        highlightImg.enabled = true;
    }

    public void Lock()
    {
        locked = true;
        lockImg.enabled = true;
        if (unlockThis != null) unlockThis.Lock();
    }// lock this button and all buttons after it
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
    }// buys this upgrade, then locks the gun's other upgrade and unlocks the next one after this
    public void Sell()
    {
        bought = false;
        if (lockThis != null) lockThis.Unlock();
        if (unlockThis != null) unlockThis.Lock();
        if (unlockThis != null && unlockThis.bought) unlockThis.Sell();
        boughtImg.enabled = false;
    }// returns the full value of this upgrade, and any bought upgrades after it

    public void togglehighlight(bool state)
    {
        highlightImg.enabled = state;
    }
}