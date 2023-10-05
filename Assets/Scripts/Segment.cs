using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public EventHandler<ExitEnterEventArgs> ExitEnter;
    SegmentManager segmentManager;

    public bool hasLeftExit;
    public bool hasRightExit;
    public bool hasFwdExit;

    private void Start()
    {
        segmentManager = FindObjectOfType<SegmentManager>();
        ExitEnter += segmentManager.OnExitEnter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCapsule"))
            OnExitEnter(false, true);
        else Debug.Log(other.name);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCapsule"))
            OnExitEnter(true, false);
        else Debug.Log(other.name);
    }

    void OnExitEnter(bool exit, bool enter)
    {
        if (ExitEnter != null)
            ExitEnter(this, new ExitEnterEventArgs(exit, enter, gameObject));
    }

    public void SpawnEnemy(GameObject enemy)
    {
        GameObject spawnedEnemy = Instantiate(enemy, transform);
        spawnedEnemy.transform.position += new Vector3(0, 2, 0);
    }
}
public class ExitEnterEventArgs : EventArgs
{
    public bool exit;
    public bool enter;
    public GameObject thisSegment;
    public ExitEnterEventArgs(bool exit, bool enter, GameObject thisSegment)
    {
        this.exit = exit;
        this.enter = enter;
        this.thisSegment = thisSegment;
    }
}