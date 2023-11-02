using System;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public EventHandler<EnterEventArgs> Enter;
    SegmentManager segmentManager;

    PickupCatalogue pickupCatalogue;

    public bool hasLeftExit;
    public bool hasRightExit;
    public bool hasFwdExit;

    public bool exited;
    public bool entered;

    public bool isHallway = false;
    public GameObject hallEndSegment;

    public int segmentIndex;

    private void Start()
    {
        pickupCatalogue = Singleton.Instance.GetComponentInChildren<PickupCatalogue>();
        segmentManager = FindObjectOfType<SegmentManager>();
        Enter += segmentManager.OnEnter;

        SpawnPickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHallway) return;
        if (other.CompareTag("PlayerCapsule"))
        {
            entered = true;
            OnEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        exited = true;
    }

    void OnEnter()
    {
        if (Enter != null)
            Enter(this, new EnterEventArgs(gameObject));
    }

    public void SpawnEnemy(GameObject enemy)
    {
        var rand = new System.Random();

        GameObject spawnedEnemy = Instantiate(enemy, transform);
        spawnedEnemy.transform.position += new Vector3((float)rand.NextDouble() * 5 - 2.5f, 2, (float)rand.NextDouble() * 5 - 2.5f);
    }

    void SpawnPickup()
    {
        var rand = new System.Random();

        if (segmentManager.currentSegmentIndex % 3 == 0 && segmentManager.currentSegmentIndex > 0 && !isHallway)
        {
            GameObject gunPickup = Instantiate(pickupCatalogue.GetRandomGun(), transform);
            gunPickup.transform.position += new Vector3((float)rand.NextDouble() * 5 - 2.5f, 1.5f, (float)rand.NextDouble() * 5 - 2.5f);
        }
    }
}
public class EnterEventArgs : EventArgs
{
    public GameObject thisSegment;
    public EnterEventArgs(GameObject thisSegment)
    {
        this.thisSegment = thisSegment;
    }
}