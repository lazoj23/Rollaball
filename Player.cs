using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Player : MonoBehaviour {

    public float speed;
    private Vector3 movement;
    private Rigidbody rb;
    private int count;
    public Text timerText;
    public Text countText;
    public float totalTime;
    public float timeLeft;
    public bool gameWon;
    public GameObject resetbutt;
    public GameObject Nextlvlbutt;
    public Text loseText;
    public Text winText;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        totalTime = 30;
        timeLeft = totalTime;
        timerText.text = "Timer: ";
        resetbutt.SetActive(false);
        Nextlvlbutt.SetActive(false);
        SetCountText ();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed * Time.deltaTime);
        timerText.text = "Timer: " + timeLeft.ToString();
        if (gameWon == false)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) 
            {
                gameObject.SetActive(false);
                gameWon = true;
                resetbutt.SetActive(true);
                loseText.text = "YOU LOSE! Try again?";
                timerText.text = "Timer: 0";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "YOU WIN!";
            Nextlvlbutt.SetActive(true);
            resetbutt.SetActive(false);
            timerText.text = "Timer:0";
            loseText.text = " ";
        }
    }
} 
