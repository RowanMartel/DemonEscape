using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    SaveLoad saveLoad;

    void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
    }

    public void Load(int saveNo)
    {
        saveLoad.Load(saveNo);
    }

    public void DeleteSave(int saveNo)
    {
        saveLoad.DeleteSave(saveNo);
    }
}