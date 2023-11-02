using System.Collections.Generic;
using UnityEngine;

public class SegmentManager : MonoBehaviour
{
    public List<GameObject> enemies;

    public List<GameObject> segmentPrefabs;
    public GameObject hallwayPrefab;
    public Transform segmentParent;

    public List<GameObject> segments = new();
    public GameObject currentSegment;
    public GameObject currentSegmentHall;

    public int currentSegmentIndex;

    enum Direction
    {
        left,
        right,
        fwd
    }

    private void Start()
    {
        currentSegmentIndex = 0;
    }

    GameObject AddHallway(Direction direction)
    {
        GameObject newSegment = Instantiate(hallwayPrefab);
        newSegment.transform.parent = segmentParent;
        newSegment.transform.eulerAngles = currentSegment.transform.eulerAngles;
        newSegment.transform.position = currentSegment.transform.position;

        switch (direction)
        {
            case Direction.left:
                newSegment.transform.eulerAngles += new Vector3(0, -90, 0);
                newSegment.transform.position -= currentSegment.transform.right * 10;
                break;
            case Direction.right:
                newSegment.transform.eulerAngles += new Vector3(0, 90, 0);
                newSegment.transform.position += currentSegment.transform.right * 10;
                break;
            case Direction.fwd:
                newSegment.transform.position += currentSegment.transform.forward * 10;
                break;
        }
        newSegment.GetComponent<Segment>().isHallway = true;
        segments.Add(newSegment);
        return newSegment;
    }

    void GenerateSegment(Direction direction)
    {
        GameObject hallway = AddHallway(direction);
        GameObject newSegment = Instantiate(GetRandomSegment());
        hallway.GetComponent<Segment>().hallEndSegment = newSegment;
        newSegment.transform.parent = segmentParent;
        newSegment.transform.eulerAngles = currentSegment.transform.eulerAngles;
        newSegment.transform.position = currentSegment.transform.position;

        switch (direction)
        {
            case Direction.left:
                newSegment.transform.eulerAngles += new Vector3(0, -90, 0);
                newSegment.transform.position -= currentSegment.transform.right * 20;
                break;
            case Direction.right:
                newSegment.transform.eulerAngles += new Vector3(0, 90, 0);
                newSegment.transform.position += currentSegment.transform.right * 20;
                break;
            case Direction.fwd:
                newSegment.transform.position += currentSegment.transform.forward * 20;
                break;
        }
        newSegment.GetComponent<Segment>().SpawnEnemy(enemies[0]);
        segments.Add(newSegment);
    }

    GameObject GetRandomSegment()
    {
        return segmentPrefabs[Random.Range(0, segmentPrefabs.Count)];
    }

    public void OnEnter(object source, EnterEventArgs e)
    {
        if (e.thisSegment.GetComponent<Segment>().exited) return;

        currentSegment = e.thisSegment.GetComponent<Segment>().hallEndSegment;
        currentSegmentHall = e.thisSegment;

        List<GameObject> segmentsToDestroy = new();

        currentSegmentIndex++;
        foreach (GameObject segment in segments)
        {
            if (segment.GetComponent<Segment>().segmentIndex <= currentSegmentIndex && segment != currentSegment && segment != currentSegmentHall)
            {
                segmentsToDestroy.Add(segment);
            }
        }
        foreach (GameObject segment in segmentsToDestroy)
        {
            segments.Remove(segment);
            Destroy(segment);
        }

        if (currentSegment.GetComponent<Segment>().hasLeftExit)
            GenerateSegment(Direction.left);
        if (currentSegment.GetComponent<Segment>().hasRightExit)
            GenerateSegment(Direction.right);
        if (currentSegment.GetComponent<Segment>().hasFwdExit)
            GenerateSegment(Direction.fwd);
    }
}