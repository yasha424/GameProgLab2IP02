using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 360f;
    public float jumpForce = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        Vector3 rotation = new Vector3(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotation);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Debug.Log(2);
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }

}
