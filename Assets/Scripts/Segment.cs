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
        Enter += segmentManager.OnEnter;// subscribe segmentManager to the on-segment-enter event

        SpawnPickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHallway || other.CompareTag("Projectile")) return;
        if (other.CompareTag("PlayerCapsule"))
        {
            entered = true;
            OnEnter();
        }// if not a hallway segment, call OnEnter
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("PlayerCapsule")) return;
        exited = true;
    }

    void OnEnter()
    {
        if (Enter != null)
        {
            Enter(this, new EnterEventArgs(gameObject));
            FindObjectOfType<Player>().Distance += Constants.distanceStep;
        }
    }// broadcasts that this segment has been entered to segmentManager

    public void SpawnEnemy()
    {
        EnemySpawnDecider spawnDecider = FindObjectOfType<EnemySpawnDecider>();
        // called before Start I think so we need this here

        var rand = new System.Random();
        GameObject enemy = spawnDecider.enemies[UnityEngine.Random.Range(0, spawnDecider.enemies.Count)];

        GameObject spawnedEnemy = Instantiate(enemy, transform);
        spawnedEnemy.transform.position += new Vector3((float)rand.NextDouble() * 5 - 2.5f, 2, (float)rand.NextDouble() * 5 - 2.5f);
    }// creates an enemy at a random position on the segment

    void SpawnPickup()
    {
        var rand = new System.Random();

        if (segmentManager.currentSegmentIndex % 10 == 0 && segmentManager.currentSegmentIndex > 0 && !isHallway)
        {
            GameObject gunPickup = Instantiate(pickupCatalogue.GetRandomGun(), transform);
            gunPickup.transform.position += new Vector3((float)rand.NextDouble() * 5 - 2.5f, 1.5f, (float)rand.NextDouble() * 5 - 2.5f);
        }
    }// creates a random pickup on every 10th non-hallway segment
}
public class EnterEventArgs : EventArgs
{
    public GameObject thisSegment;
    public EnterEventArgs(GameObject thisSegment)
    { this.thisSegment = thisSegment; }
}