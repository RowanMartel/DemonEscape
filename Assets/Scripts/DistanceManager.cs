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

    private void Awake()
    {
        trackerMeterStep = (trackerEnd.position.x - trackerStart.position.x) / Constants.maxDistance;
    }

    public void MoveTracker(float distance)
    {
        this.distance = distance;
        tracker.transform.position = trackerStart.position;
        tracker.transform.position += new Vector3(trackerMeterStep * distance, 0, 0);
        if (distance >= Constants.maxDistance)
        {

        }
        Debug.Log(tracker.transform.position);
    }
}