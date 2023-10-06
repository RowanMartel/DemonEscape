using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public EventHandler<EnterEventArgs> Enter;
    SegmentManager segmentManager;

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
        segmentManager = FindObjectOfType<SegmentManager>();
        Enter += segmentManager.OnEnter;
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
        GameObject spawnedEnemy = Instantiate(enemy, transform);
        spawnedEnemy.transform.position += new Vector3(0, 2, 0);
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