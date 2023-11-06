using System.Collections.Generic;
using UnityEngine;

public class PickupCatalogue : MonoBehaviour
{
    public List<GameObject> gunPickups;
    public List<GameObject> powerUps;

    public GameObject GetRandomGun()
    {
        var random = new System.Random();
        return gunPickups[random.Next(gunPickups.Count)];
    }
}// class for getting random pickups in segments