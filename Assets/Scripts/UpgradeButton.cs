using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade upgrade;
    UpgradeScreen upgradeScreen;
    Button button;

    void Start()
    {
        upgradeScreen = GetComponentInParent<UpgradeScreen>();
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate () { upgradeScreen.ShowUpgradeDetails(upgrade); });
    }
}