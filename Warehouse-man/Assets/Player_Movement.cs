using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 100f;
    Rigidbody rb;

    private float x;
    private float z;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(x, 0, z).normalized;

        rb.linearVelocity = new Vector3(movement.x * moveSpeed,0,movement.z * moveSpeed) * Time.deltaTime;

        Debug.Log(rb.linearVelocity);
    }
}
