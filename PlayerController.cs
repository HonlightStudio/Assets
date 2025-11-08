using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions input;
    private Rigidbody rb;
    private bool grounded;
    
    
    public Transform cameraTransform;
    public float speed;
    public Vector3 Offset ;
    public float jumpForce;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new InputSystem_Actions();
    }


    private void Start()
    {
        input.Player.Jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    public void Jump()
    {
        if(grounded)rb.AddForce(Vector3.up * jumpForce);
    }
    
    private void OnDisable()
    {
        input.Disable();
    }

    
    void Update()
    {
        Vector3 move = input.Player.Move.ReadValue<Vector2>(); 
        Debug.Log(move);
        move = new Vector3(move.x, 0, move.y);
        rb.AddForce(move.normalized * speed);
        cameraTransform.position = transform.position + Offset;
    }


    private void OnCollisionEnter(Collision other)
    {
        grounded = other.gameObject.CompareTag("Ground");
    }

    private void OnCollisionExit(Collision other)
    {
        
        
        if(other.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}
