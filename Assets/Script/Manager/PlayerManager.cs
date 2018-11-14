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

    //攻撃の配列
    [SerializeField]
    List<GameObject>[] attackCollider = new List<GameObject>[2];
    [SerializeField]
    List<AttackTable>[] attackParameter = new List<AttackTable>[2];


    Attack[] attack = { new Attack() , new Attack()};
    
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
                    StatusManager.Instance.SetCommandOnePlayer(9);
                    return;
                }
                if (Input.GetAxis("Vertical") == -1)
                {
                    StatusManager.Instance.SetCommandOnePlayer(3);
                    return;
                    //しゃがみ状態に
                }
                StatusManager.Instance.SetCommandOnePlayer(6);
                float x = Speed;
                P1rb.AddForce(new Vector2(x, 0));
                return;
            }

            if (Input.GetAxis("Horizontal") == -1)
            {
                if (Input.GetAxis("Vertical") == 1)
                {
                    StatusManager.Instance.SetCommandOnePlayer(7);
                    return;
                }
                if (Input.GetAxis("Vertical") == -1)
                {
                    StatusManager.Instance.SetCommandOnePlayer(1);
                    return;
                    //しゃがみ状態に

                }
                StatusManager.Instance.SetCommandOnePlayer(4);
                float x = Speed;
                P1rb.AddForce(new Vector2(-x, 0));
                return;
            }

            
            if (Input.GetAxis("Horizontal") <= 0.5 && Input.GetAxis("Horizontal") >= -0.5)
            {
                if (Input.GetAxis("Vertical") == 1 && !P1jump)
                {
                    if (Input.GetAxis("Vertical") == 1)
                    {
                        StatusManager.Instance.SetCommandOnePlayer(8);
                        return;
                    }
                    P1rb.AddForce(new Vector2(0, Jump));
                    P1jump = true;
                }
                if (Input.GetAxis("Vertical") == -1)
                {
                    StatusManager.Instance.SetCommandOnePlayer(2);
                    return;
                    //しゃがみ状態に
                }
                if (Input.GetAxis("Vertical") <= 0.5 && Input.GetAxis("Vertical") >= -0.5)
                {
                    StatusManager.Instance.SetCommandOnePlayer(5);
                    return;
                }
                
                

            }
        }
        if (Player2)
        {
            if (Input.GetAxis("Horizontal2") == 1)
            {
                if (Input.GetAxis("Vertical2") == 1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(9);
                    return;
                }
                if (Input.GetAxis("Vertical2") == -1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(3);
                    return;
                    //しゃがみ状態に
                }

                StatusManager.Instance.SetCommandTwoPlayer(6);
                float x = Speed;
                P2rb.AddForce(new Vector2(x, 0));
            }

            if (Input.GetAxis("Horizontal2") == -1)
            {
                if (Input.GetAxis("Vertical2") == 1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(7);
                    return;
                }
                if (Input.GetAxis("Vertical2") == -1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(1);
                    return;
                    //しゃがみ状態に
                }
                StatusManager.Instance.SetCommandTwoPlayer(4);
                float x = Speed;
                P2rb.AddForce(new Vector2(-x, 0));
                return;
            }

            if (Input.GetAxis("Horizontal2") <= 0.5 && Input.GetAxis("Horizontal2") >= -0.5)
            {
                if (Input.GetAxis("Vertical2") == 1 && !P2jump)
                {
                    if (Input.GetAxis("Vertical2") == 1)
                    {
                        StatusManager.Instance.SetCommandTwoPlayer(8);
                        return;
                    }
                    P2rb.AddForce(new Vector2(0, Jump));
                    P2jump = true;
                }
                if (Input.GetAxis("Vertical2") == -1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(2);
                    return;
                    //しゃがみ状態に
                }
                if (Input.GetAxis("Vertical2") <= 0.5 && Input.GetAxis("Vertical2") >= -0.5)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(5);
                    return;
                }
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
