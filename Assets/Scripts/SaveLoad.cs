using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public int saveFileNum;

    [SerializeField] Sprite emptySave;

    public void Save(Sprite preview)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile" + saveFileNum + ".dat");

        SaveData data = new SaveData(preview);
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

            SceneManager.LoadScene(Constants.upgradeScreenSceneIndex);
        }
        else SceneManager.LoadScene(Constants.gameplaySceneIndex);
    }

    public Sprite GetPreview(int saveFileNum)
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
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

    public SaveData(Sprite preview)
    {
        this.preview = preview;
    }
}