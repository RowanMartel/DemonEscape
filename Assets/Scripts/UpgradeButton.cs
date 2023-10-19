using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade.Upgrades upgrade;
    [Range(1, 3)] public int level;
    UpgradeScreen upgradeScreen;
    Button button;
    Sprite icon;

    void Start()
    {
        upgradeScreen = GetComponentInParent<UpgradeScreen>();
        button = GetComponent<Button>();
        icon = GetComponent<Image>().sprite;

        button.onClick.AddListener(delegate () { upgradeScreen.ShowUpgradeDetails(upgrade, level, icon); });
    }
}