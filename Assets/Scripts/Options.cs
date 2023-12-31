using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] GameObject upgradesBtn;
    [SerializeField] GameObject titleBtn;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == Constants.gameplaySceneIndex)
        {
            if (gameManager.Paused) Close();
            else Open();
        }
    }// open options if in gameplay and the player hits esc

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }

    public void Close()
    {
        gameManager.Paused = false;
        canvas.enabled = false;
    }
    public void Open()
    {
        gameManager.Paused = true;
        canvas.enabled = true;

        // only enable end round button if in gameplay
        if (SceneManager.GetActiveScene().buildIndex == Constants.gameplaySceneIndex)
            upgradesBtn.SetActive(true);
        else upgradesBtn.SetActive(false);

        // don't enable quit to title button if on title screen
        if (SceneManager.GetActiveScene().buildIndex == Constants.titleScreenSceneIndex)
            titleBtn.SetActive(false);
        else titleBtn.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndRound()
    {
        Player player = FindObjectOfType<Player>();
        GameManager.money += player.Money;// add the round's spoils to the overall money
        gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
    }
    public void QuitToTitle()
    {
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }
}