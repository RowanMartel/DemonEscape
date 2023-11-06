using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static List<Upgrade> upgrades = new();

    public void ApplyUpgrades()
    {
        foreach (Upgrade upgrade in upgrades)
            upgrade.Apply();
    }// apply upgrade values to constants
}