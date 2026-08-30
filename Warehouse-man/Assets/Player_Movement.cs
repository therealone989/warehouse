using Unity.Cinemachine;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Mouse")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform head;

    private Rigidbody rb;

    private float x;
    private float z;

    private float mouseX;
    private float mouseY;

    private float yaw;
    private float pitch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.eulerAngles.y;
    }

    void Update()
    {
        // WASD
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");


        // Maus
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;


        // Links / Rechts
        yaw += mouseX;


        // Hoch / Runter
        pitch -= mouseY;

        // Verhindert komplettes Überschlagen
        pitch = Mathf.Clamp(pitch, -85f, 85f);


        // Nur Head hoch/runter drehen
        head.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }

    void FixedUpdate()
    {
        // Lokale WASD Richtung
        Vector3 inputDirection = new Vector3(x, 0, z).normalized;

        Vector3 moveDir = transform.rotation * inputDirection;
        // Richtung entsprechend Playerrotation drehen
        Vector3 targetVelocity = rb.position + moveDir * moveSpeed * Time.deltaTime;
        rb.MovePosition(targetVelocity);
    }
}
