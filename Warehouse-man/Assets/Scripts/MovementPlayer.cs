using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [Header("Bewegungsvariablen")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float sprintSpeed = 14f;

    [SerializeField] private Transform movementReference;

    private Rigidbody rb;

    private Vector2 moveInput;
    private Vector3 movementForce;

    private bool isSprinting;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // EINMAL PRO FRAME
    void Update()
    {

        Vector3 moveDirection = (movementReference.forward * moveInput.y) +
                                (movementReference.right * moveInput.x);
        moveDirection.y = 0f;
        movementForce = moveDirection.normalized;
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        Vector3 velocity = movementForce * currentSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSprinting = true;
        }

        if (context.canceled)
        {
            isSprinting = false;
        }
    }
}
