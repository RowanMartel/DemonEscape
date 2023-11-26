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
    GameManager gameManager;

    private void Awake()
    {
        trackerMeterStep = (trackerEnd.position.x - trackerStart.position.x) / Constants.maxDistance;
    }// set the amount the tracker icon should move whenever distance increases

    private void Start()
    {
        enemySpawnDecider = FindObjectOfType<EnemySpawnDecider>();
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
    }

    public void MoveTracker(float distance)
    {
        this.distance = distance;
        tracker.transform.position = trackerStart.position;
        tracker.transform.position += new Vector3(trackerMeterStep * distance / 2, 0, 0);
        if (this.distance >= Constants.maxDistance)
        {
            gameManager.WinGame();
        }// win game once target distance reached

        enemySpawnDecider.UpdateBias(distance);
    }
}