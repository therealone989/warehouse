using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Text Missionen")]
    [SerializeField] TextMeshProUGUI textBrown;
    [SerializeField] TextMeshProUGUI textGreen;
    [SerializeField] TextMeshProUGUI textYellow;
    [SerializeField] TextMeshProUGUI textBlue;

    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] TextMeshProUGUI missonsCompletedText;

    [SerializeField] GameObject timer;

    public int neededMissions = 3;

    public int brownMission;
    public int greenMission;
    public int yellowMission;
    public int blueMission;

    public int brownBox = 0;
    public int greenBox = 0;
    public int yellowBox = 0;
    public int blueBox = 0;

    public bool hasCompletedMissions;
    int completedMissions;

    float timeRemaining = 300f;
    bool timeRunning = false;

    void Start()
    {
        SetMission();
        timer.SetActive(false);
    }



    private void Update()
    {
        CheckTimer();
        SetText();
        WinCondition();

    }

    public void WinCondition()
    {
        if (hasCompletedMissions) return;
        if (brownBox == brownMission && greenBox == greenMission && yellowBox == yellowMission && blueBox == blueMission)
        {
            completedMissions++;
            if (completedMissions >= neededMissions)
            {
                hasCompletedMissions = true;
                brownBox = 0;
                greenBox = 0;
                yellowBox = 0;
                blueBox = 0;
                Debug.Log("GESCHAFFT!");
                return;
            }
            else
            {
                SetMission();
            }
        }
    }
    public void CheckTimer()
    {
        if (timeRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRunning = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartTimer();
        }
    }
    public void StartTimer()
    {
        timer.SetActive(true);
        timeRunning = true;
    }
    public void SetMission()
    {
        brownBox = 0;
        greenBox = 0;
        yellowBox = 0;
        blueBox = 0;

        brownMission = Random.Range(2, 4);
        greenMission = Random.Range(2, 4);
        yellowMission = Random.Range(2, 4);
        blueMission = Random.Range(2, 4);
    }

    public void SetText()
    {
        textBrown.text = "Braune Boxen: " + brownBox + "/" + brownMission;
        textGreen.text = "Gruene Boxen: " + greenBox + "/" + greenMission;
        textYellow.text = "Gelbe Boxen: " + yellowBox + "/" + yellowMission;
        textBlue.text = "Blaue Boxen: " + blueBox + "/" + blueMission;
        textTimer.text = "Verbliebende Zeit: " + Mathf.CeilToInt(timeRemaining);
        missonsCompletedText.text = "Missionen: " + completedMissions + "/" + neededMissions;
    }
}
