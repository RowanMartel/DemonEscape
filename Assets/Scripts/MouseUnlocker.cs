using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseUnlocker : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void Update()
    {
        if (gameManager.Paused == true || SceneManager.GetActiveScene().buildIndex != Constants.gameplaySceneIndex)
            Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }// lock the mouse if in gameplay and not paused
}