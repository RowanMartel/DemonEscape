using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Options options;
    public Results results;
    [SerializeField] UpgradeManager upgradeManager;

    public float money;

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
    }

    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        money = 500;
    }

    public void NewGame()
    {
        money = 0;
        upgradeManager.upgrades.Clear();
    }

    public void LoadScene(int buildIndex)
    {
        Constants.Reset();

        switch (buildIndex)
        {
            case Constants.gameplaySceneIndex:
                upgradeManager.ApplyUpgrades();
                break;
        }

        SceneManager.LoadScene(buildIndex);
    }

    void OnSceneChanged(Scene replacedScene, Scene newScene)
    {
        options.Close();
        results.Close();

        switch (newScene.buildIndex)
        {
            case Constants.gameplaySceneIndex:
                Player player = FindObjectOfType<Player>();
                player.gameManager = this;
                player.results = results;
                break;
            case Constants.upgradeScreenSceneIndex:
                break;
        }
    }
}