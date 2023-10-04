using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject player;

    void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        
    }
}