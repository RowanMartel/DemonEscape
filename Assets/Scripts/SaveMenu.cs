using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    SaveLoad saveLoad;

    [SerializeField] Image save1;
    [SerializeField] Image save2;
    [SerializeField] Image save3;

    [SerializeField] Sprite save1Img;
    [SerializeField] Sprite save2Img;
    [SerializeField] Sprite save3Img;

    void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
        InitSaveImages();
    }

    void InitSaveImages()
    {
        Debug.Log("areharhaeh");
        save1.sprite = save1Img;
        save2.sprite = save2Img;
        save3.sprite = save3Img;
    }

    public void Load(int saveNo)
    {
        saveLoad.Load(saveNo);
    }
}