using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    float Speed;
    [SerializeField]
    float Jump;

    Rigidbody2D rb;
    bool jump = false;

 //   float h = Input.GetAxis("Horizontal");
   // float v = Input.GetAxis("Vertical");

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    
    // Update is called once per frame
    void FixedUpdate () {
        Attack();
        PadMove();
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;   
    }


    void Attack() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("パンチしました");
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("X");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("A");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("B");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("Y");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("LB");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("RB");
        }
    }


    void PadMove() {

        if (Input.GetAxis("Horizontal") == 1)
        {
            if (Input.GetAxis("Vertical") == 1)
            {
                Debug.Log("9");
                //return;
            }
            if (Input.GetAxis("Vertical") == -1)
            {
                Debug.Log("3");
                //return;
            }
            Debug.Log("6");
            float x = Speed;
            rb.AddForce(new Vector2(x,0));
        }

        if (Input.GetAxis("Horizontal") == -1)
        {
            if (Input.GetAxis("Vertical") == 1)
            {
                Debug.Log("7");
                //return;
            }
            if (Input.GetAxis("Vertical") == -1)
            {
                Debug.Log("1");
                //return;
            }
            Debug.Log("4");
            float x = Speed;
            rb.AddForce(new Vector2(-x, 0));
        }

        if (Input.GetAxis("Vertical") == 1 && jump ==  false)
        {
            if (Input.GetAxis("Vertical") == 1)
            {
                Debug.Log("8");
                //return;
            }
            float y = Jump;
            rb.AddForce(new Vector2(0, y));
            jump = true;
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            Debug.Log("2");
            //return;

        //しゃがみ状態に
        }
        if (Input.GetAxis("Horizontal") <=0.5 && Input.GetAxis("Horizontal") >= -0.5 && Input.GetAxis("Vertical") <= 0.5 && Input.GetAxis("Vertical") >= -0.5)
        {
            Debug.Log("5");

        }
    }

}
