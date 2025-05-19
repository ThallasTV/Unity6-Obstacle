using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float xRotationSpeed;
    [SerializeField] private float yRotationSpeed;
    [SerializeField] private float zRotationSpeed;
    // Update is called once per frame

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
        }
    }
    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(xRotationSpeed * Time.deltaTime,
                                                        yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime));
        }
    }
}
