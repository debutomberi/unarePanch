using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static public Player instance;
    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    [SerializeField]
    float Speed;
    [SerializeField]
    float Jump;

    public GameObject Player1;
    public GameObject Player2;

    List<int> P1List = new List<int>();
    List<int> P2List = new List<int>();

    Rigidbody2D rb;
    bool jump = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    
    // Update is called once per frame
    void FixedUpdate () {
        Player1Attack();
        Player1Move();
        Player2Attack();
        Player2Move();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;   
    }


    void Player1Attack() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("パンチしました");
        }

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            Debug.Log("X");
        }
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            Debug.Log("A");
        }
        if (Input.GetKeyDown("joystick 1 button 2"))
        {
            Debug.Log("B");
        }
        if (Input.GetKeyDown("joystick 1 button 3"))
        {
            Debug.Log("Y");
        }
        if (Input.GetKeyDown("joystick 1 button 4"))
        {
            Debug.Log("LB");
        }
        if (Input.GetKeyDown("joystick 1 button 5"))
        {
            Debug.Log("RB");
        }
    }

    void Player2Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("パンチしました");
        }

        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            Debug.Log("X");
        }
        if (Input.GetKeyDown("joystick 2 button 1"))
        {
            Debug.Log("A");
        }
        if (Input.GetKeyDown("joystick 2 button 2"))
        {
            Debug.Log("B");
        }
        if (Input.GetKeyDown("joystick 2 button 3"))
        {
            Debug.Log("Y");
        }
        if (Input.GetKeyDown("joystick 2 button 4"))
        {
            Debug.Log("LB");
        }
        if (Input.GetKeyDown("joystick 2 button 5"))
        {
            Debug.Log("RB");
        }
    }
    void Player1Move() {

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

    void Player2Move()
    {

        if (Input.GetAxis("Horizontal2") == 1)
        {
            if (Input.GetAxis("Vertical2") == 1)
            {
                Debug.Log("9");
                //return;
            }
            if (Input.GetAxis("Vertical2") == -1)
            {
                Debug.Log("3");
                //return;
            }

            Debug.Log("6");
            float x = Speed;
            rb.AddForce(new Vector2(x, 0));
        }

        if (Input.GetAxis("Horizontal2") == -1)
        {
            if (Input.GetAxis("Vertical2") == 1)
            {
                Debug.Log("7");
                //return;
            }
            if (Input.GetAxis("Vertical2") == -1)
            {
                Debug.Log("1");
                //return;
            }
            Debug.Log("4");
            float x = Speed;
            rb.AddForce(new Vector2(-x, 0));
        }

        if (Input.GetAxis("Vertical2") == 1 && jump == false)
        {
            if (Input.GetAxis("Vertical2") == 1)
            {
                Debug.Log("8");
                //return;
            }
            float y = Jump;
            rb.AddForce(new Vector2(0, y));
            jump = true;
        }
        if (Input.GetAxis("Vertical2") == -1)
        {
            Debug.Log("2");
            //return;

            //しゃがみ状態に
        }
        if (Input.GetAxis("Horizontal2") <= 0.5 && Input.GetAxis("Horizontal2") >= -0.5 && Input.GetAxis("Vertical2") <= 0.5 && Input.GetAxis("Vertical2") >= -0.5)
        {
            Debug.Log("5");

        }
    }

}
