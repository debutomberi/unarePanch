using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehavior<PlayerManager>
{

    /*
    static public Player instance;
    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    */

    [SerializeField]
    float Speed;
    [SerializeField]
    float Jump;

    //1Pの攻撃
    [SerializeField]
    List<GameObject> attackColliderOnePlayer = new List<GameObject>();
    [SerializeField]
    List<AttackTable> attackParameterOnePlayer = new List<AttackTable>();

    //2Pの攻撃
    [SerializeField]
    List<GameObject> attackColliderTwoPlayer = new List<GameObject>();
    [SerializeField]
    List<AttackTable> attackParameterTwoPlayer = new List<AttackTable>();

    //2Pの攻撃
    [SerializeField]
    List<GameObject>[] attackCollider = new List<GameObject>[2];
    [SerializeField]
    List<AttackTable>[] attackParameter = new List<AttackTable>[2];


    Attack[] attack = { new Attack() , new Attack()};

    //public string r;//6
    //public string l;//4
    //public string q;//1
    //public string d;//2
    //public string e;//3
    //public string z;//7
    //public string j;//8
    //public string c;//9
    //public string S;//656
    //public string s;//454

    GameObject Player1;
    GameObject Player2;


    Rigidbody2D P1rb;
    Rigidbody2D P2rb;
    bool P1jump;
    bool P2jump;

    void Start()
    {
        Player1 = GameObject.Find("Player");
        Player2 = GameObject.Find("Player2");
        P1rb = Player1.GetComponent<Rigidbody2D>();
        P2rb = Player2.GetComponent<Rigidbody2D>();

        attackCollider[0] = attackColliderOnePlayer;
        attackCollider[1] = attackColliderTwoPlayer;

        attackParameter[0] = attackParameterOnePlayer;
        attackParameter[1] = attackParameterTwoPlayer;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Attack();
        Move();
    }

    public void OnPlayerCollisionEnter(int player,Collision2D collision) {
        if(player == 1) {
            P1jump = false;
        }
        else if(player == 2) {
            P2jump = false;
        }
        else {
            Debug.LogError("プレイヤーの接触には１か２を選択してください");
        }
    } 

    void Attack()
    {
        if (Player1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
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
        if (Player2)
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
    }
    
    void Move()
    {
        if (Player1)
        {

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
                    //しゃがみ状態に
                }

                Debug.Log("6");
                float x = Speed;
                P1rb.AddForce(new Vector2(x, 0));
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
                    //しゃがみ状態に

                }
                Debug.Log("4");
                float x = Speed;
                P1rb.AddForce(new Vector2(-x, 0));
            }

            if (Input.GetAxis("Vertical") == 1 && !P1jump)
            {
                if (Input.GetAxis("Vertical") == 1)
                {
                    Debug.Log("8");
                    //return;
                }
                float y = Jump;
                P1rb.AddForce(new Vector2(0, y));
                P1jump = true;
            }
            if (Input.GetAxis("Vertical") == -1)
            {
                Debug.Log("2");
                //return;

                //しゃがみ状態に
            }
            if (Input.GetAxis("Horizontal") <= 0.5 && Input.GetAxis("Horizontal") >= -0.5 && Input.GetAxis("Vertical") <= 0.5 && Input.GetAxis("Vertical") >= -0.5)
            {
                Debug.Log("5");

            }
        }
        if (Player2)
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
                    //しゃがみ状態に
                }

                Debug.Log("6");
                float x = Speed;
                P2rb.AddForce(new Vector2(x, 0));
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
                    //しゃがみ状態に
                }
                Debug.Log("4");
                float x = Speed;
                P2rb.AddForce(new Vector2(-x, 0));
            }

            if (Input.GetAxis("Vertical2") == 1 && P2jump == false)
            {
                if (Input.GetAxis("Vertical2") == 1)
                {
                    Debug.Log("8");
                    //return;
                }
                float y = Jump;
                P2rb.AddForce(new Vector2(0, y));
                P2jump = true;
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

    void AttackOccurrence(int AttackNum , int player)
    {
        if (attack[player-1].AttackCheck) { return; }
        IEnumerator coroutine = attack[player-1].SetParamete(attackParameter[player-1][AttackNum], attackCollider[player-1][AttackNum]);
        StartCoroutine(coroutine);
    }
}
