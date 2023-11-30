using System.Collections.Generic;
using UnityEngine;

public class PickupCatalogue : MonoBehaviour
{
    public List<GameObject> pickups;

    public GameObject GetRandomGun()
    {
        var random = new System.Random();
        return pickups[random.Next(pickups.Count)];
    }
}// class for getting random pickups