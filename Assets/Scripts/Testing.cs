using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Rigidbody rb;
    bool isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject go = GameObject.FindWithTag("Player");
        GameObject go2 = GameObject.Find("Player");
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3);
        isGameStarted = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameStarted)
        {
            rb.AddForce(transform.forward.normalized * 10, ForceMode.Impulse);
        transform.Rotate(Vector3.up, 20 * Time.deltaTime);
        Debug.Log(rb.velocity, gameObject);
        }
        
    }
}
