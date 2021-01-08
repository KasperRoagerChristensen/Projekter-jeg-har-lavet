using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject Object;
    public float Respawn;
    private bool dead = false;
    public float points = 0f;
    public Renderer rend;
    private float RespawnTime;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        RespawnTime = Respawn;
    }

    void Update()
    {
        
        if (dead == true)
        {
            Respawn -= Time.deltaTime;
        }
        if (Respawn <= 0)
        {
            dead = false;
            rend.enabled = true;
            Respawn = RespawnTime;
            points = 0;
            Object.transform.position = new Vector3(0, 10, 0);
        }
        points += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kill")
        {
            rend.enabled = false;
            dead = true;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "score : " + points);
    }
}
