using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades = new();

    public void ApplyUpgrades()
    {
        foreach (Upgrade upgrade in upgrades)
            upgrade.Apply();
    }
}