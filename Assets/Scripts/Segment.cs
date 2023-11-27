using System;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public EventHandler<EnterEventArgs> Enter;
    SegmentManager segmentManager;
    DistanceManager distanceManager;

    PickupCatalogue pickupCatalogue;

    public bool hasLeftExit;
    public bool hasRightExit;
    public bool hasFwdExit;

    public bool exited;
    public bool entered;

    public bool isHallway = false;
    public GameObject hallEndSegment;

    public int segmentIndex;

    [SerializeField] MeshCollider backWallSolid;
    [SerializeField] SegmentBackWall backWallTrigger;

    [SerializeField] Material brickWallMat;
    [SerializeField] Material skullWallMat;
    [SerializeField] List<Renderer> wallRenderers;

    private void Start()
    {
        distanceManager = FindObjectOfType<DistanceManager>();
        pickupCatalogue = Singleton.Instance.GetComponentInChildren<PickupCatalogue>();
        segmentManager = FindObjectOfType<SegmentManager>();
        Enter += segmentManager.OnEnter;// subscribe segmentManager to the on-segment-enter event
        DetermineWallTexture();
        SpawnPickup();
    }

    private void OnTriggerStay(Collider other)
    {
        SegmentBackWall backWallSolid = GetComponentInChildren<SegmentBackWall>();// for some reason it needs to be called here too

        if (!isHallway || !other.CompareTag("PlayerCapsule") || entered || (!backWallSolid.passedThrough && segmentManager.currentSegmentIndex > 0)) return;
        entered = true;
        OnEnter();
    }// if not a hallway segment, call OnEnter
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("PlayerCapsule")) return;
        exited = true;
    }

    void OnEnter()
    {
        if (Enter != null)
        {
            backWallSolid = transform.GetChild(0).GetComponent<MeshCollider>();// for some reason it needs to be called here too
            backWallSolid.enabled = true;
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

        if (segmentManager.currentSegmentIndex % 5 == 0 && segmentManager.currentSegmentIndex > 0 && !isHallway)
        {
            GameObject gunPickup = Instantiate(pickupCatalogue.GetRandomGun(), transform);
            gunPickup.transform.position += new Vector3((float)rand.NextDouble() * 5 - 2.5f, 1.5f, (float)rand.NextDouble() * 5 - 2.5f);
        }
    }// creates a random pickup on every 5th non-hallway segment

    void DetermineWallTexture()
    {
        Material textureToApply;
        if (distanceManager.distance > Constants.maxDistance / 2)
            textureToApply = skullWallMat;
        else textureToApply = brickWallMat;
        foreach (Renderer renderer in wallRenderers)
            renderer.material = textureToApply;
    }// sets the wall textures based on distance through the level
}
public class EnterEventArgs : EventArgs
{
    public GameObject thisSegment;
    public EnterEventArgs(GameObject thisSegment)
    { this.thisSegment = thisSegment; }
}