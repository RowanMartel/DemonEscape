using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Options options;
    [SerializeField] Results results;

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

    void OnSceneChanged(Scene current, Scene next)
    {
        options.Close();
        results.Close();

        switch (current.buildIndex)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }
}