using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsSys : MonoBehaviour
{
    public float points = 0f;
    void Start()
    {

    }

    void Update()
    {
        points += Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "score : " + points);
    }

}
