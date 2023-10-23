using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public int saveFileNum;

    [SerializeField] Sprite emptySave;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    public void Save(Sprite preview)
    {
        BinaryFormatter bf = new();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");

        SaveData data = new(preview, upgradeManager.upgrades, gameManager.money);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(int saveFileNum)
    {
        this.saveFileNum = saveFileNum;

        if (File.Exists(Application.persistentDataPath + "/saveFile.dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
            gameManager.money = data.money;
            upgradeManager.upgrades = data.upgrades;
        }
        else
        {
            gameManager.NewGame();
            gameManager.LoadScene(Constants.gameplaySceneIndex);
        }
    }

    public Sprite GetPreview(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            return data.preview;
        }
        else return emptySave;
    }
}

[Serializable]
class SaveData
{
    public Sprite preview;
    public List<Upgrade> upgrades;
    public float money;

    public SaveData(Sprite preview, List<Upgrade> upgrades, float money)
    {
        this.preview = preview;
        this.upgrades = upgrades;
        this.money = money;
    }
}