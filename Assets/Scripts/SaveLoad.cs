using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static int saveFileNum;// number out of 3 that points to the save file currently being played

    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    public void Save()
    {
        BinaryFormatter bf = new();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");

        SaveData data = new(UpgradeManager.upgrades, GameManager.money, GameManager.maxKills);
        bf.Serialize(file, data);
        file.Close();
    }// serialize and save relevant data into a .dat file

    public void Load(int saveFileNumPar)
    {
        saveFileNum = saveFileNumPar;

        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
            GameManager.money = data.money;
            UpgradeManager.upgrades = data.upgrades;
            GameManager.maxKills = data.maxKills;
        }// load the selected save file into the upgrade screen
        else
        {
            gameManager.NewGame();
            gameManager.LoadScene(Constants.gameplaySceneIndex);
        }// if the save doesn't exist, load into gameplay with a new game instead
    }
    public void DeleteSave(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
            File.Delete(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");
    }

    public int GetSaveMoney(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            return data.money;
        }
        else
            return -1;
    }// returns the money in the given save
    public int GetSaveKills(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            return data.maxKills;
        }
        else
            return -1;
    }// returns the max kills in the given save
    public int GetSaveUpgrades(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            int upgradeCount = 0;
            foreach (Upgrade upgrade in data.upgrades)
                upgradeCount ++;
            return upgradeCount;
        }
        else
            return -1;
    }// returns the amount of upgrades in the given save
}

[Serializable]
class SaveData
{
    public List<Upgrade> upgrades;// list of upgrades unlocked in the save file
    public int money;
    public int maxKills;

    public SaveData(List<Upgrade> upgrades, int money, int maxKills)
    {
        this.upgrades = upgrades;
        this.money = money;
        this.maxKills = maxKills;
    }
}// contains and serializes all data that needs to be stored between game sessions