using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBackWall : MonoBehaviour
{
    public bool passedThrough = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerCapsule")) return;
        passedThrough = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("PlayerCapsule")) return;
        passedThrough = true;
    }
}// back wall prevents player from going backwards through the level