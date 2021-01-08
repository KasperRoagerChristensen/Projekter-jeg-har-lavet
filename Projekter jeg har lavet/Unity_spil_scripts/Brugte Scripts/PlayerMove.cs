using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        
    }

    void FixedUpdate()
    {
      //  rb.AddForce(direction * speed * Time.deltaTime);
    }
}
