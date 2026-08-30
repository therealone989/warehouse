using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            switch (collision.gameObject.tag)
            {
                case "Brown":
                    if (gameManager.brownBox == gameManager.brownMission) return;
                    gameManager.brownBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Green":
                    if (gameManager.greenBox == gameManager.greenMission) return;
                    gameManager.greenBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Yellow":
                    if (gameManager.yellowBox == gameManager.yellowMission) return;
                    gameManager.yellowBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Blue":
                    if (gameManager.blueBox == gameManager.blueMission) return;
                    gameManager.blueBox++;
                    Destroy(collision.gameObject);
                    break;
                default:

                    break;
            }
        }
    }
}
