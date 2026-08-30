using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensibility;
    [SerializeField] private Transform head;

    private Vector2 mouseInput;
    private float pitch;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, mouseInput.x * sensibility);
        pitch -= mouseInput.y * sensibility;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        head.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
        Debug.Log(mouseInput);
    }
}
