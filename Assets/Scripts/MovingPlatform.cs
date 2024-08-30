using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum PlatformType { Right, Up }
    public PlatformType platformType;
    public bool movingRight;
    public bool movingUp;
    private Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformType == PlatformType.Right)
        {

            if (movingRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (transform.position.x >= endPosition.x)
            {
                movingRight = false;
            }
            if (transform.position.x <= startPosition.x)
            {
                movingRight = true;
            }
        }
        else if (platformType == PlatformType.Up)
        {
            if (movingUp)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (transform.position.y >= endPosition.y)
            {
                movingUp = false;
            }
            if (transform.position.y <= startPosition.y)
            {
                movingUp = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            collision.transform.localScale = Vector3.one;
        }
    }
}
