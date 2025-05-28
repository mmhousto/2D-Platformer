using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Debug.Log("You are HOLDING the Jump Button");
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            Debug.Log("You are HOLDING the Tab Key");
        }

        Debug.Log($"Horizontal Input: {Input.GetAxis("Horizontal")}");
        Debug.Log($"Vertical Input Raw: {Input.GetAxisRaw("Vertical")}");

        if (Input.GetButtonDown("Fire"))
        {
            Debug.Log("You Pressed Down the Fire Button");
        }

        // Left Mouse Button
        if (Input.GetMouseButton(0))
        {
            Debug.Log("You are Pressing the Left Mouse Button");
        }

        // Right Mouse Button
        if (Input.GetMouseButton(1))
        {
            Debug.Log("You are Pressing the Right Mouse Button");
        }

        // Middle Mouse Button
        if (Input.GetMouseButton(2))
        {
            Debug.Log("You are Pressing the Middle Mouse Button");
        }
    }
}
