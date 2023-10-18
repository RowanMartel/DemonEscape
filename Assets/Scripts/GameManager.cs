using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Options options;
    [SerializeField] Results results;
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

    void Awake()
    {
        if (Singleton.Instance == GetComponentInParent<Singleton>())
            SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public void NewGame()
    {
        money = 0;
        upgradeManager.upgrades.Clear();
    }

    void OnSceneChanged(Scene replacedScene, Scene newScene)
    {
        Constants.Reset();

        options.Close();
        results.Close();

        switch (newScene.buildIndex)
        {
            case Constants.gameplaySceneIndex:
                upgradeManager.ApplyUpgrades();
                break;
        }
    }
}