using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    public void CaptureScreenshot(int saveNo)
    {
        Debug.Log("saving to file " +  saveNo.ToString());
        switch (saveNo)
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