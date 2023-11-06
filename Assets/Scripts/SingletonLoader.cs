using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonLoader : MonoBehaviour
{
    [SerializeField] Scene singletonScene;

    void Awake()
    {
        SceneManager.LoadScene(Constants.singletonSceneIndex, LoadSceneMode.Additive);
    }
}