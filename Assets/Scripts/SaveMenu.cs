using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    SaveLoad saveLoad;

    [SerializeField] Image save1;
    [SerializeField] Image save2;
    [SerializeField] Image save3;

    void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
        InitSaveImages();
    }

    void InitSaveImages()
    {
        save1.sprite = saveLoad.GetPreview(1);
        save2.sprite = saveLoad.GetPreview(2);
        save3.sprite = saveLoad.GetPreview(3);
    }

    public void Load(int saveNo)
    {
        saveLoad.Load(saveNo);
    }
}