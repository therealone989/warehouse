using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Text Missionen")]
    [SerializeField] TextMeshProUGUI textBrown;
    [SerializeField] TextMeshProUGUI textGreen;
    [SerializeField] TextMeshProUGUI textYellow;
    [SerializeField] TextMeshProUGUI textBlue;

    int brownMission;
    int greenMission;
    int yellowMission;
    int blueMission;

    public int brownBox = 0;
    public int greenBox = 0;
    public int yellowBox = 0;
    public int blueBox = 0;

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
    }

    public void SetMission()
    {
        brownMission = Random.Range(2, 10);
        greenMission = Random.Range(2, 10);
        yellowMission = Random.Range(2, 10);
        blueMission = Random.Range(2, 10);
    }

}
