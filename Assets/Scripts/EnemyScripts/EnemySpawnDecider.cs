using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDecider : MonoBehaviour
{
    [SerializeField] GameObject slimeGunner;
    [SerializeField] GameObject plasmaImp;
    public List<GameObject> enemies = new();
    // weighted list for less random enemy picking

    private void Start()
    {
        ResetList();
    }

    public void ResetList()
    {
        enemies.Add(slimeGunner);
        enemies.Add(slimeGunner);
        enemies.Add(slimeGunner);
        enemies.Add(slimeGunner);
        enemies.Add(plasmaImp);
        enemies.Add(plasmaImp);
    }// resets spawn bias
}