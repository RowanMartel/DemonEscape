using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    [SerializeField] SaveLoad saveLoad;

    public void CaptureScreenshot()
    {
        switch (SaveLoad.saveFileNum)
        {
            case 1:
                ScreenCapture.CaptureScreenshot("Assets/SaveImages/Save1Img.png");
                break;
            case 2:
                ScreenCapture.CaptureScreenshot("Assets/SaveImages/Save2Img.png");
                break;
            case 3:
                ScreenCapture.CaptureScreenshot("Assets/SaveImages/Save3Img.png");
                break;
        }
    }
}