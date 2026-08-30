using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PickUpBox : MonoBehaviour
{
    public float distance = 2f;
    public Image crosshair;
    public GameObject pickUpText;
    private GameObject currentBox;
    private RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera cam = Camera.main;
        pickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (currentBox.tag != null)
            {
                currentBox.SetActive(false);
            }
            else return;

        }
    }


}
