using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Object;
    public Rigidbody rb;
    public float thrust;
    private float newPos;

    // Start is called before the first frame update
    void Start()
    {
        newPos = Object.transform.position.x;
    }


    // Update is called once per frame
    void Update()
    {
        if (newPos >= 20)
        {
            newPos = -20;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Object.transform.position = new Vector3(newPos, transform.position.y, -44);
            newPos++;
        }
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, thrust * Time.deltaTime);
    }
}
