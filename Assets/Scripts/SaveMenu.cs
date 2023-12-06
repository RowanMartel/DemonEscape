using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    SaveLoad saveLoad;

    [SerializeField] TMP_Text save1Txt;
    [SerializeField] TMP_Text save2Txt;
    [SerializeField] TMP_Text save3Txt;

    void Start()
    {
        saveLoad = Singleton.Instance.GetComponentInChildren<SaveLoad>();
        SetSaveText();
    }

    public void Load(int saveNo)
    {
        saveLoad.Load(saveNo);
    }

    public void DeleteSave(int saveNo)
    {
        saveLoad.DeleteSave(saveNo);
        SetSaveText();
    }

    void SetSaveText()
    {
        // file 1
        int file1Kills = saveLoad.GetSaveKills(1);
        int file1Money = saveLoad.GetSaveMoney(1);
        int file1Upgrades = saveLoad.GetSaveUpgrades(1);
        if (file1Kills < 0 || file1Money < 0 || file1Upgrades < 0)
            save1Txt.text = "Empty Save";
        else
            save1Txt.text = $"Money: ${file1Money} \nUpgrades: {file1Upgrades} \nMax Kills: {file1Kills}";
        // file 2
        int file2Kills = saveLoad.GetSaveKills(2);
        int file2Money = saveLoad.GetSaveMoney(2);
        int file2Upgrades = saveLoad.GetSaveUpgrades(2);
        if (file2Kills < 0 || file2Money < 0 || file2Upgrades < 0)
            save2Txt.text = "Empty Save";
        else
            save2Txt.text = $"Money: ${file2Money} \nUpgrades: {file2Upgrades} \nMax Kills: {file2Kills}";
        // file 3
        int file3Kills = saveLoad.GetSaveKills(3);
        int file3Money = saveLoad.GetSaveMoney(3);
        int file3Upgrades = saveLoad.GetSaveUpgrades(3);
        if (file3Kills < 0 || file3Money < 0 || file3Upgrades < 0)
            save3Txt.text = "Empty Save";
        else
            save3Txt.text = $"Money: ${file3Money} \nUpgrades: {file3Upgrades} \nMax Kills: {file3Kills}";
    }
}