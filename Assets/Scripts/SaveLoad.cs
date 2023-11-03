using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static int saveFileNum;

    /*[SerializeField] Sprite save1Img;
    [SerializeField] Sprite save2Img;
    [SerializeField] Sprite save3Img;*/

    [SerializeField] Sprite emptySave;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] GameManager gameManager;

    public void Save()
    {
        /*Sprite preview = emptySave;
        switch (saveFileNum)
        {
            case 1:
                preview = save1Img;
                break;
            case 2:
                preview = save2Img;
                break;
            case 3:
                preview = save3Img;
                break;
        }*/
        
        BinaryFormatter bf = new();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");

        SaveData data = new(/*preview, */upgradeManager.upgrades, gameManager.money);
        bf.Serialize(file, data);
        file.Close();
    }

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
            gameManager.money = data.money;
            upgradeManager.upgrades = data.upgrades;
        }
        else
        {
            gameManager.NewGame();
            gameManager.LoadScene(Constants.gameplaySceneIndex);
        }
    }
    public void DeleteSave(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat"))
        {
            File.Delete("/saveFile" + saveFileNum + ".dat");
        }
    }

    /*public Sprite GetPreview(int saveFileNum)
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
    }*/
}

[Serializable]
class SaveData
{
    //public Sprite preview;
    public List<Upgrade> upgrades;
    public float money;

    public SaveData(/*Sprite preview, */List<Upgrade> upgrades, float money)
    {
        //this.preview = preview;
        this.upgrades = upgrades;
        this.money = money;
    }
}