using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class PickUpBox : MonoBehaviour
{
    public float distance = 2f;
    public Image crosshair;
    public GameObject pickUpText;
    [SerializeField] private GameObject currentBox;
    private RaycastHit hit;

    [SerializeField] private bool hasBox = false;
    [SerializeField] GameObject[] boxes = new GameObject[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera cam = Camera.main;
        pickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBox) return;

        PickUp();

        if (hit.collider == null)
        {
            crosshair.color = Color.white;
            pickUpText.SetActive(false);
            return;
        }
        switch (hit.collider.tag)
        {
            case "Brown":
                SwitchMode(Color.brown, true);
                break;
            case "Green":
                SwitchMode(Color.green, true);
                break;
            case "Yellow":
                SwitchMode(Color.yellow, true);
                break;
            case "Blue":
                SwitchMode(Color.blue, true);
                break;
            default:
                crosshair.color = Color.white;
                pickUpText.SetActive(false);
                currentBox = null;
                break;
        }
    }
    public void SwitchMode(Color color,bool setActive)
    {
        crosshair.color = color;
        pickUpText.SetActive(setActive);
        currentBox = hit.collider.gameObject;
    }

    public void PickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out hit, distance);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentBox == null) return;
            // RICHTIGE BOX AKTIVIEREN
            for (int i = 0; i < boxes.Length; i++)
            {
                if(currentBox.CompareTag(boxes[i].tag))
                {
                    currentBox.SetActive(false);
                    hasBox = true;
                    crosshair.color = Color.white;
                    pickUpText.SetActive(false);
                    boxes[i].SetActive(true);
                    hit = new RaycastHit();
                    currentBox = null;
                    return;
                }
            }
        }
    }


}
