using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Torqy : MonoBehaviour
{
    public TextMeshProUGUI speedLabel;
    public TextMeshProUGUI countdownLabel;
    public Vector3 direction;
    public int speed;
    private Rigidbody rb;
    private int countdown = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countdownLabel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speedLabel.text = $"Speed: {speed}";
        if(countdownLabel != null )
            countdownLabel.text = countdown.ToString();
    }

    private void AddTorque()
    {
        rb.AddTorque(direction * speed);
    }

    private void OnMouseDown()
    {
        AddTorque();
    }

    public void IncreaseSpeed()
    {
        speed += 5;
    }

    public void DecreaseSpeed()
    {
        speed -= 5;
    }

    public void ResetScene()
    {
        countdownLabel.gameObject.SetActive(true);
        StartCoroutine(CountDownReset());
    }

    private IEnumerator CountDownReset()
    {
        while(countdown > 0)
        {
            yield return new WaitForSeconds(1);
            countdown--;
        }
        SceneManager.LoadScene("Test");

    }
}
