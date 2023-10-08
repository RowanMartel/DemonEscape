using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonLoader : MonoBehaviour
{
    [SerializeField] Scene singletonScene;

    void Awake()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }
}