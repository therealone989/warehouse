using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickUpBox : MonoBehaviour
{
    [Header("Attributes Raycast")]
    public float distance = 2f;
    public float throwStrengh = 2f;

    [Header("UI")]
    public Image crosshair;
    public GameObject pickUpText;

    [Header("Boxes and Shootpoint")]
    [SerializeField] GameObject[] boxes = new GameObject[4];
    [SerializeField] GameObject[] prefabBoxes = new GameObject[4];
    [SerializeField] private Transform shootPoint;

    [Header("Variables -Do not change-")]
    [SerializeField] private bool hasBox = false;
    [SerializeField] private GameObject currentBox;
    [SerializeField] private GameObject droppingBox;
    [SerializeField] private GameObject holdingBox;
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
        DropOff();
        if (hasBox) return;
        PickUp();
        BoxCheck();
    }

    // Checkt Ray collision und Switcht Modes.
    public void BoxCheck()
    {
        // Hier checken wir ob unser hit ein Collider trifft.
        if (hit.collider == null || hit.collider.gameObject.layer == 7)
        {
            crosshair.color = Color.white;
            pickUpText.SetActive(false);
            // Box die wir gerade anschauen um die richtige box in der hand zu aktivieren // deaktivieren.
            // Hier gibt es kein Collider deswegen keine Schleifen durchlauf (Iteration).
            currentBox = null;
            return;
        }
        // Wenn unser Ray ein collider hittet, dann switchen wir durch die tags.
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

    // Allgemeine Methode um die Farbe zu wechseln und Pickup Text zu steuern.
    // Bestimmt die box die wir anschauen als currentBox.
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
        if (!hasBox && Input.GetKeyDown(KeyCode.E))
        {
            // Wenn Spieler keine Box anschaut raus aus der Methode.
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
                    holdingBox = boxes[i];
                    // Resettet Hit weil sonst wird der letzte hit gespeichert und der Text bleibt aktiv.
                    hit = new RaycastHit();
                    droppingBox = prefabBoxes[i];
                    Destroy(currentBox);
                    return;
                }
            }
        }
    }

    public void DropOff()
    {
        if(hasBox && Input.GetKeyDown(KeyCode.E)) {
            
            GameObject spawnedBox = Instantiate(droppingBox, shootPoint.transform.position, shootPoint.localRotation);
            spawnedBox.SetActive(true);
            Rigidbody boxRb = spawnedBox.GetComponent<Rigidbody>();
            boxRb.AddRelativeForce(transform.forward * throwStrengh,ForceMode.Impulse);
            holdingBox.SetActive(false);
            holdingBox = null;
            hasBox = false;
            
        }
    }

}
