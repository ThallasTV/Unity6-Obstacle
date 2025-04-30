using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Speed of the object
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] InputAction jumpAction;
    [SerializeField] InputAction moveAction;

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded = true;

    


    private void OnEnable()
    {
        jumpAction.Enable();
        moveAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
        moveAction.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call the MovePlayer method to handle movement
    }

    void MovePlayer()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed); // Move at 5 units per second

        if(jumpAction.triggered && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); // Jump with an impulse force
            isGrounded = false; // Set isGrounded to false when jumping
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true when colliding with the ground
        }
    }
}
