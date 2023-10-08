using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void Update()
    {
        
    }

    void OnSceneChanged(Scene current, Scene next)
    {
        switch (current.buildIndex)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }
}