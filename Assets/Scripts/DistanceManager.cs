using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform trackerStart;
    [SerializeField] Transform trackerEnd;
    [SerializeField] GameObject tracker;
    float trackerMeterStep;
    public float distance;
    EnemySpawnDecider enemySpawnDecider;

    private void Awake()
    {
        trackerMeterStep = (trackerEnd.position.x - trackerStart.position.x) / Constants.maxDistance;
    }// set the amount the tracker icon should move whenever distance increases

    private void Start()
    {
        enemySpawnDecider = FindObjectOfType<EnemySpawnDecider>();
    }

    public void MoveTracker(float distance)
    {
        this.distance = distance;
        tracker.transform.position = trackerStart.position;
        tracker.transform.position += new Vector3(trackerMeterStep * distance, 0, 0);
        if (distance >= Constants.maxDistance)
        {

        }// win game once target distance reached

        enemySpawnDecider.UpdateBias(distance);
    }
}