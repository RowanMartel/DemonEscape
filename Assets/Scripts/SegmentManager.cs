using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SegmentManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;

    [SerializeField] List<GameObject> segmentPrefabs;
    [SerializeField] Transform segmentParent;

    List<GameObject> exitedSegments = new List<GameObject>();
    [SerializeField] GameObject currentSegment;
    GameObject nextSegmentLeft;
    GameObject nextSegmentRight;
    GameObject nextSegmentFwd;

    enum Direction
    {
        left,
        right,
        fwd
    }

    void GenerateSegment(Direction direction)
    {
        GameObject newSegment = Instantiate(GetRandomSegment());
        newSegment.transform.parent = segmentParent;
        newSegment.transform.eulerAngles = currentSegment.transform.eulerAngles;
        newSegment.transform.position = currentSegment.transform.position;

        switch (direction)
        {
            case Direction.left:
                newSegment.transform.eulerAngles += new Vector3(0, -90, 0);
                newSegment.transform.position -= currentSegment.transform.right * 10;
                nextSegmentLeft = newSegment;
                break;
            case Direction.right:
                newSegment.transform.eulerAngles += new Vector3(0, 90, 0);
                newSegment.transform.position += currentSegment.transform.right * 10;
                nextSegmentRight = newSegment;
                break;
            case Direction.fwd:
                newSegment.transform.position += currentSegment.transform.forward * 10;
                nextSegmentFwd = newSegment;
                break;
        }
        newSegment.GetComponent<Segment>().SpawnEnemy(enemies[0]);
    }

    GameObject GetRandomSegment()
    {
        return segmentPrefabs[Random.Range(0, segmentPrefabs.Count)];
    }

    public void OnExitEnter(object source, ExitEnterEventArgs e)
    {
        if (e.exit)
        {
            exitedSegments.Add(e.thisSegment);
            if (exitedSegments.Count >= 2)
            {
                Destroy(exitedSegments[0]);
                exitedSegments.RemoveAt(0);
            }
        }
        else if (e.enter)
        {
            currentSegment = e.thisSegment;
            
            if (currentSegment == nextSegmentFwd)
            {
                if (nextSegmentLeft != null) Destroy(nextSegmentLeft);
                if (nextSegmentRight != null) Destroy(nextSegmentRight);
            }
            else if (currentSegment == nextSegmentLeft)
            {
                if (nextSegmentFwd != null) Destroy(nextSegmentFwd);
                if (nextSegmentRight != null) Destroy(nextSegmentRight);
            }
            else if (currentSegment == nextSegmentRight)
            {
                if (nextSegmentFwd != null) Destroy(nextSegmentFwd);
                if (nextSegmentLeft != null) Destroy(nextSegmentLeft);
            }

            if (currentSegment.GetComponent<Segment>().hasLeftExit) GenerateSegment(Direction.left);
            if (currentSegment.GetComponent<Segment>().hasRightExit) GenerateSegment(Direction.right);
            if (currentSegment.GetComponent<Segment>().hasFwdExit) GenerateSegment(Direction.fwd);
        }
    }
}