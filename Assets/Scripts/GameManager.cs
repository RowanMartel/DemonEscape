using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Options options;
    public Results results;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] SaveLoad saveLoad;
    [SerializeField] AudioManager audioManager;

    public static int money;
    public static int maxKills;

    private bool paused = false;
    public bool Paused
    { 
        get { return paused; } 
        set
        {
            paused = value;
            if (value) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }// sets timeScale appropriately when paused is modified

    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        SetBGM();
    }// subscribe OnSceneChanged to the scene change event

    public void NewGame()
    {
        money = 0;
        UpgradeManager.upgrades.Clear();
    }

    public void LoadScene(int buildIndex)
    {
        Constants.Reset();

        switch (buildIndex)
        {
            case Constants.gameplaySceneIndex:
                upgradeManager.ApplyUpgrades();
                break;// apply upgrades if entering gameplay
        }

        SceneManager.LoadScene(buildIndex);
    }

    // method called on activeSceneChanged event
    void OnSceneChanged(Scene replacedScene, Scene newScene)
    {// subscribed to scene load event
        options.Close();
        results.Close();

        switch (newScene.buildIndex)
        {
            case Constants.gameplaySceneIndex:
                Player player = FindObjectOfType<Player>();
                player.gameManager = this;
                player.results = results;
                break;// give player necessary variables
            case Constants.upgradeScreenSceneIndex:
                saveLoad.Save();
                break;
        }
        SetBGM();
    }// initializes all values relating to the loaded scene

    public void WinGame()
    {
        LoadScene(Constants.endingScreenSceneIndex);
    }

    void SetBGM()
    {
        AudioManager.BGMEnum BGM = AudioManager.BGMEnum.title;
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case Constants.gameplaySceneIndex:
                BGM = AudioManager.BGMEnum.gameplay1;
                break;
            case Constants.endingScreenSceneIndex:
                BGM = AudioManager.BGMEnum.credits;
                break;
            case Constants.savesMenuSceneIndex:
            case Constants.upgradeScreenSceneIndex:
                BGM = AudioManager.BGMEnum.menus;
                break;
            case Constants.titleScreenSceneIndex:
                BGM = AudioManager.BGMEnum.title;
                break;
        }
        audioManager.SetBGM(BGM);
    }// sets the BGM for the current scene
}