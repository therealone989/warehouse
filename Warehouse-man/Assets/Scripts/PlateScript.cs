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
                    gameManager.brownBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Green":
                    gameManager.greenBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Yellow":
                    gameManager.yellowBox++;
                    Destroy(collision.gameObject);
                    break;
                case "Blue":
                    gameManager.blueBox++;
                    Destroy(collision.gameObject);
                    break;
                default:

                    break;
            }
        }
    }
}
