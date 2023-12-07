using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform trackerStart;
    [SerializeField] Transform trackerEnd;
    [SerializeField] GameObject tracker;
    [SerializeField] TMP_Text trackerText;
    float trackerMeterStep;
    public int kills;
    EnemySpawnDecider enemySpawnDecider;
    GameManager gameManager;
    AudioManager audioManager;
    bool halfwayReached;

    private void Awake()
    {
        trackerMeterStep = (trackerEnd.localPosition.x - trackerStart.localPosition.x) / Constants.requiredKills;
    }// set the amount the tracker icon should move whenever kills increases

    private void Start()
    {
        audioManager = Singleton.Instance.GetComponentInChildren<AudioManager>();
        enemySpawnDecider = FindObjectOfType<EnemySpawnDecider>();
        gameManager = Singleton.Instance.GetComponentInChildren<GameManager>();
        UpdateKillText();
    }

    public void MoveTracker(int kills)
    {
        this.kills += kills;
        tracker.transform.position = trackerStart.position;
        tracker.transform.position += new Vector3(trackerMeterStep * this.kills / 2, 0, 0);
        if (this.kills >= Constants.requiredKills)
        {
            gameManager.WinGame();
        }// win game once target kills reached
        else if (this.kills >= Constants.requiredKills / 2 && !halfwayReached)
        {
            halfwayReached = true;
            audioManager.SetBGM(AudioManager.BGMEnum.gameplay2);
        }// change BGM to level 2 when halfway through

        if (this.kills > GameManager.maxKills)
            GameManager.maxKills = this.kills;

        UpdateKillText();

        enemySpawnDecider.UpdateBias(this.kills);
    }// move the tracker to show how far along the player is in kill progress

    void UpdateKillText()
    {
        trackerText.text = $"{this.kills}/{Constants.requiredKills} Kills";
    }// show how many kills the player has racked up through text
}