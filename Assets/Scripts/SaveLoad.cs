using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public int saveFileNum;

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");

        SaveData data = new SaveData();
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(int saveFileNum)
    {
        this.saveFileNum = saveFileNum;

        if (File.Exists(Application.persistentDataPath + "/saveFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(Constants.gameplaySceneIndex);
        }
    }
}

[Serializable]
class SaveData
{
    public SaveData()
    {
        
    }
}