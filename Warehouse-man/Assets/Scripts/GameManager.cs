using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Text Missionen")]
    [SerializeField] TextMeshProUGUI textBrown;
    [SerializeField] TextMeshProUGUI textGreen;
    [SerializeField] TextMeshProUGUI textYellow;
    [SerializeField] TextMeshProUGUI textBlue;

    public int brownMission;
    public int greenMission;
    public int yellowMission;
    public int blueMission;

    public int brownBox = 0;
    public int greenBox = 0;
    public int yellowBox = 0;
    public int blueBox = 0;

    private bool hasCompletedMissions;

    void Start()
    {
        SetMission();
    }



    private void Update()
    {

        textBrown.text = "Braune Boxen: " + brownBox + "/" + brownMission;
        textGreen.text = "Grüne Boxen: " + greenBox + "/" + greenMission;
        textYellow.text = "Gelbe Boxen: " + yellowBox + "/" + yellowMission;
        textBlue.text = "Blaue Boxen: " + blueBox + "/" + blueMission;

        if(brownBox == brownMission && greenBox == greenMission && yellowBox == yellowMission && blueBox == blueMission)
        {
            SetMission();
        }

   
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

}
