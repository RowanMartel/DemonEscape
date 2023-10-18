using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades;

    public void ApplyUpgrades()
    {
        foreach (Upgrade upgrade in upgrades)
            upgrade.Apply();
    }
}