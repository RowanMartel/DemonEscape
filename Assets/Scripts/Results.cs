using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        Close();
    }

    public void TitleBtnMethod()
    {
        canvas = GetComponent<Canvas>();
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }

    public void Close()
    {
        canvas.enabled = false;
        gameManager.Paused = false;
    }
    public void Open()
    {
        canvas.enabled = true;
        gameManager.Paused = true;

        KillManager killManager = FindObjectOfType<KillManager>();
        Player player = FindObjectOfType<Player>();

        text.text = $"Money Collected: ${player.Money} \n\nEnemies Killed: {killManager.kills}/{Constants.requiredKills}";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndRound()
    {
        gameManager.LoadScene(Constants.upgradeScreenSceneIndex);
    }
    public void QuitToTitle()
    {
        gameManager.LoadScene(Constants.titleScreenSceneIndex);
    }
}