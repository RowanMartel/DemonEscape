using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform trackerStart;
    [SerializeField] Transform trackerEnd;
    [SerializeField] GameObject tracker;
    float trackerMeterStep;
    public int kills;
    EnemySpawnDecider enemySpawnDecider;
    GameManager gameManager;
    AudioManager audioManager;
    bool halfwayReached;

    private void Awake()
    {
        trackerMeterStep = (trackerEnd.position.x - trackerStart.position.x) / Constants.requiredKills;
    }// set the amount the tracker icon should move whenever kills increase

    private void Start()
    {
        audioManager = Singleton.Instance.GetComponentInChildren<AudioManager>();
        enemySpawnDecider = FindObjectOfType<EnemySpawnDecider>();
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
    }

    public void MoveTracker(int kills)
    {
        this.kills += kills;
        tracker.transform.position = trackerStart.position;
        tracker.transform.position += new Vector3(trackerMeterStep * this.kills / 2, 0, 0);
        if (this.kills >= Constants.requiredKills)
        {
            gameManager.WinGame();
        }// win game once target distance reached
        else if (this.kills >= Constants.requiredKills / 2 && !halfwayReached)
        {
            halfwayReached = true;
            audioManager.SetBGM(AudioManager.BGMEnum.gameplay2);
        }// change BGM to level 2 when halfway through

        if (this.kills > GameManager.maxKills)
            GameManager.maxKills = this.kills;

        enemySpawnDecider.UpdateBias(this.kills);
    }
}