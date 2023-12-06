using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDecider : MonoBehaviour
{
    [SerializeField] GameObject slimeGunner;
    [SerializeField] GameObject plasmaImp;
    [SerializeField] GameObject slimeSlasher;
    [SerializeField] GameObject brainCan;
    public List<GameObject> enemies = new();
    // weighted list for less random enemy picking

    bool check1;
    bool check2;
    bool check3;
    bool check4;
    bool check5;
    // checkpoint variables for UpdateBias

    private void Start()
    {
        ResetList();
    }

    public void ResetList()
    {
        enemies.Add(slimeGunner);
        enemies.Add(slimeGunner);
        enemies.Add(slimeGunner);
        enemies.Add(plasmaImp);
    }// resets spawn bias

    public void UpdateBias(float distance)
    {
        if (distance >= (Constants.requiredKills / 4) * 3 && !check5)
        {
            enemies.Add(brainCan);
            enemies.Remove(plasmaImp);
            check5 = true;
        }
        else if (distance >= (Constants.requiredKills / 3) * 2 && !check4)
        {
            enemies.Remove(slimeGunner);
            enemies.Add(slimeSlasher);
            check4 = true;
        }
        else if (distance >= Constants.requiredKills / 2 && !check3)
        {
            enemies.Add(brainCan);
            check3 = true;
        }
        else if (distance >= Constants.requiredKills / 3 && !check2)
        {
            enemies.Add(slimeSlasher);
            enemies.Remove(slimeGunner);
            check2 = true;
        }
        else if (distance >= Constants.requiredKills / 4 && !check1)
        {
            enemies.Add(plasmaImp);
            check1 = true;
        }
    }// makes the game progressively harder as the player progresses
}