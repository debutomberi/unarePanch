using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;


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
    GameObject effect;
    public float Speed;
    [SerializeField]
    public float Jump;

    //1Pの攻撃
    [SerializeField]
    public List<GameObject> attackColliderOnePlayer = new List<GameObject>();
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
    [SerializeField]
    SpriteRenderer[] image = new SpriteRenderer[2];


    Attack[] attack = { new Attack() , new Attack()};
    
    GameObject Player1;
    GameObject Player2;
    GameObject Center;

    Vector2 p1Pos;
    Vector2 p2Pos;
    public Vector2 centerPos;

    Rigidbody2D P1rb;
    Rigidbody2D P2rb;
    //ジャンプしているか
    [HideInInspector]public bool P1jump;
    [HideInInspector]public bool P2jump;
    //ガードしているか
    bool[] guard = { false, false };
    //しゃがんでいるか
    bool[] shit = { false, false };

    //立ちの当たり判定
    [SerializeField]
    GameObject[] standCollider = new GameObject[2];
    //しゃがみの当たり判定
    [SerializeField]
    GameObject[] shitCollider = new GameObject[2];

    bool timeControl;

    bool center1p;
    bool center2p;
    //移動可能か
    bool move1P = true;
    bool move2P = true;

    //デフォルトのSprite
    [SerializeField]
    Sprite[] defultSprite = new Sprite[2];
    //移動するときのsprites
    [SerializeField]
    Sprite[] moveSprites1p = new Sprite[3];
    [SerializeField]
    Sprite[] moveSprites2p = new Sprite[3];
    //しゃがみのsprite
    [SerializeField]
    Sprite[] shitSprite = new Sprite[2];
    //ガードのSprite
    [SerializeField]
    Sprite[] guardSprite = new Sprite[2];
    //ダメージを食らったときのsprite
    [SerializeField]
    Sprite[] damageSprite = new Sprite[2];
    //ジャンプのSprite
    [SerializeField]
    Sprite[] jumpSprite1p = new Sprite[2];
    [SerializeField]
    Sprite[] jumpSprite2p = new Sprite[2];
    //K.OのSprite
    [SerializeField]
    Sprite[] kOSprite1p = new Sprite[2];
    [SerializeField]
    Sprite[] kOSprite2p = new Sprite[2];
    //次の歩きの絵を表示するまでの時間
    int[] walkTime = { 0, 0 };
    //次に表示する歩きの絵の番号
    int[] nextWalk = { 0, 0 };
    bool[] walkCheck = { false, false };
    //ジャンプのアニメーションをしたか
    bool[] jumpAnimEnd = { false, false };


    public int missileDirection = 1;

    //勝負がついたか
    public bool isPlaying = true;
    //K.Oされたプレイヤー、Falseが１P
    public bool kOPlayer = false;
    //K.Oのアニメ中かどうか
    public bool kOanimeTime = false;

    public bool Move1P
    {
        get{return move1P;}
        set{move1P = value;}
    }
    public bool Move2P
    {
        get { return move2P; }
        set { move2P = value; }
    }

    public bool[] Guard
    {
        get{return guard;}
        set{guard = value;}
    }

    void Start()
    {

        center1p = false;
        center2p = false;

        Center = GameObject.Find("Center");
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        P1rb = Player1.GetComponent<Rigidbody2D>();
        P2rb = Player2.GetComponent<Rigidbody2D>();

        attackCollider[0] = attackColliderOnePlayer;
        attackCollider[1] = attackColliderTwoPlayer;

        attackParameter[0] = attackParameterOnePlayer;
        attackParameter[1] = attackParameterTwoPlayer;

        for (int i = 0; i <= attackCollider[0].Count - 1; i++)
        {
            attackCollider[0][i].gameObject.SetActive(false);
        }
        for (int i = 0; i <= attackCollider[1].Count - 1; i++)
        {
            attackCollider[1][i].gameObject.SetActive(false);
        }

        int id1 = PlayerSporn.Instance.GetPlayerSelectID(PLAYERID.ID_1);
        //PlayerGet exampleAsset = AssetDatabase.LoadAssetAtPath<PlayerGet>("Assets/CharaInfo" + id1 + ".asset");
        //exampleAsset.GetCharaID();

    }
    private void Update()
    {
        if (!isPlaying)
        {
            if (kOanimeTime) { KOAnim(kOPlayer); }
            else
            {
                if (Input.GetKeyDown("joystick 1 button 2"))
                {
                    SceneManagers.Instance.ChangeSceneState();
                }
                else if (Input.GetKeyDown("joystick 2 button 2"))
                {
                    SceneManagers.Instance.ChangeSceneState();
                }
            }
        }
        else
        {
            Attack();
        }
        ReturnTitle();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPlaying) return;
        Move1Input();
        Move2Input();
        if (move1P && !P1jump && !attack[0].AttackCheck) { Move(1); }
        if (move2P && !P2jump && !attack[1].AttackCheck) { Move(2); }
        if (P1jump) { JumpAnim(1); }else if (!P1jump && jumpAnimEnd[0]) { jumpAnimEnd[0] = false; }
        if (P2jump) { JumpAnim(2); } else if (!P2jump && jumpAnimEnd[1]) { jumpAnimEnd[1] = false; }
        GetPos();
        CenterLook();
    }

    public void OnPlayerCollisionEnter(int player,Collision2D collision) {
        if(player == 1&&P1jump) {
            P1jump = false;
        }
        else if(player == 2&&P2jump) {
            P2jump = false;
        }
        //else if(player !=1||player !=2){
        //    Debug.LogError("プレイヤーの接触には１か２を選択してください");
        //}
    } 

    void Attack()
    {
        if (!P1jump && move1P)
        {
            //DEBUG
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("パンチしました");
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(1, 1); }
                else { AttackOccurrence(0, 1); }
                
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("キックしました");
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(3, 1); }
                else { AttackOccurrence(2, 1); }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("飛び道具しました");
                if (center1p) { missileDirection = -1; }
                else if (!center1p) { missileDirection = 1; }
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(5, 1); }
                else { AttackOccurrence(4, 1); }
            }
            if(Input.GetKeyDown(KeyCode.V))
            {
                if (StatusManager.Instance.DeathblowGuage[1] == 100)
                {
                    StatusManager.Instance.GuageUse(1);
                    AttackOccurrence(6, 1);
                    UIManager.Instance.PageChenge();
                }
            }
            //DEBUG

            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                Debug.Log("パンチしました");
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(1, 1); }
                else { AttackOccurrence(0, 1); }
            }
            if (Input.GetKeyDown("joystick 1 button 1"))
            {
                Debug.Log("キックしました");
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(3, 1); }
                else { AttackOccurrence(2, 1); }
            }
            if (Input.GetKeyDown("joystick 1 button 2"))
            {
                Debug.Log("飛び道具しました");
                if (center1p) { missileDirection = -1; }
                else if (!center1p) { missileDirection = 1; }
                if (shitCollider[0].activeInHierarchy) { AttackOccurrence(5, 1); }
                else { AttackOccurrence(4, 1); }
            }
            if (Input.GetKeyDown("joystick 1 button 3"))
            {
                if (StatusManager.Instance.DeathblowGuage[1] == 100)
                {
                    StatusManager.Instance.GuageUse(1);
                    UIManager.Instance.PageChenge();
                    timeControl = true;
                    StartCoroutine("OnePlayerCamera");
                }
            }
            if (Input.GetKeyDown("joystick 1 button 4"))
            {
                //Debug.Log("LB");
                

            }
            if (Input.GetKeyDown("joystick 1 button 5"))
            {
                //Debug.Log("RB");
            }
        }
        if (!P2jump && move2P)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Debug.Log("パンチしました");
            }

            if (Input.GetKeyDown("joystick 2 button 0"))
            {
                Debug.Log("パンチしました");
                if (shitCollider[1].activeInHierarchy) { AttackOccurrence(1, 2); }
                else { AttackOccurrence(0, 2); }
            }
            if (Input.GetKeyDown("joystick 2 button 1"))
            {
                if (shitCollider[1].activeInHierarchy) { AttackOccurrence(3, 2); }
                else { AttackOccurrence(2, 2); }
            }
            if (Input.GetKeyDown("joystick 2 button 2"))
            {
                if (center2p) { missileDirection = 1; }
                else if (!center2p) { missileDirection = -1; }
                if (shitCollider[1].activeInHierarchy) { AttackOccurrence(5, 2); }
                else { AttackOccurrence(4, 2); }
            }
            if (Input.GetKeyDown("joystick 2 button 3"))
            {
                if (StatusManager.Instance.DeathblowGuage[0] == 100)
                {
                    StatusManager.Instance.GuageUse(0);
                    UIManager.Instance.PageChenge();
                    timeControl = true;
                    StartCoroutine("TwoPlayerCamera");
                    
                }
            }
            if (Input.GetKeyDown("joystick 2 button 4"))
            {
                //Debug.Log("LB");
                
                //DeathblowOccurrence(1, 2);

            }
            if (Input.GetKeyDown("joystick 2 button 5"))
            {
                //Debug.Log("RB");
            }
        }
    }
    
    void Move1Input()
    {
        
        if (Input.GetAxis("Horizontal") > 0.6)
        {
            if (Input.GetAxis("Vertical") > 0.6)
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
            
        }

        if (Input.GetAxis("Horizontal") < -0.6)
        {
            if (Input.GetAxis("Vertical") >0.6)
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
            
        }
    
        if (Input.GetAxis("Horizontal") <= 0.5 && Input.GetAxis("Horizontal") >= -0.5)
        {
            if (Input.GetAxis("Vertical") >= 0.8 && !P1jump)
            {
                if (Input.GetAxis("Vertical") >= 0.8)
                {
                    StatusManager.Instance.SetCommandOnePlayer(8);
                    return;
                }
            }
            if (Input.GetAxis("Vertical") <= -0.8)
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

    void Move2Input()
    {
        
        if (Input.GetAxis("Horizontal2") > 0.6)
        {
            if (Input.GetAxis("Vertical2") > 0.6)
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
            
            }

        if (Input.GetAxis("Horizontal2") < -0.6)
        {
            if (Input.GetAxis("Vertical2") > 0.6)
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
        }

        if (Input.GetAxis("Horizontal2") <= 0.5 && Input.GetAxis("Horizontal2") >= -0.5)
        {
            if (Input.GetAxis("Vertical2") >= 0.8 && !P2jump)
            {
                if (Input.GetAxis("Vertical2") == 1)
                {
                    StatusManager.Instance.SetCommandTwoPlayer(8);
                    return;
                }

            }
            if (Input.GetAxis("Vertical2") <= -0.8)
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

    void Move(int player)
    {
        if(player ==1 && !move1P) { return; }
        if (player == 2 && !move2P) { return; }
        //if(player <= 3) { return; }
        char command = StatusManager.Instance.CheckCommand(player);
        for(int i =0;i < guard.Length; i++)
        {
            guard[i] = false;
        }
        for(int i=0;i < shit.Length; i++)
        {
            shit[i] = false;
        }
        switch (command){
            //6方向に移動
            case 'r':
                if (player == 1)
                {
                    Player1.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                    if (center1p) { guard[0] = true;}

                }
                else if(player == 2)
                {
                    Player2.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                    if (!center1p) { guard[1] = true;}
                    
                }
                break;
            //6方向にステップ
            case 'S':
                if (player == 1) { Step(0.2f, Player1, move1P,1); }
                else if (player == 2) { Step(0.2f, Player2, move2P,2); }
                break;
            //4方向に移動
            case 'l':
                if (player == 1)
                {
                    Player1.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
                    guard[1] = true;
                    if (!center1p) { guard[0] = true; }
                }
                else if (player == 2)
                {
                    Player2.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
                    if (center1p) { guard[1] = true;}

                }
                break;
            //4方向にステップ
            case 's':
                if (player == 1) { Step(-0.2f, Player1, move1P,1); }
                else if (player == 2) { Step(-0.2f, Player2, move2P,2); }
                break;
            //垂直ジャンプ
            case 'j':
                if (player == 1) {
                    P1rb.AddForce(new Vector2(0, Jump));
                    P1jump = true;
                }
                else if (player == 2) {
                    P2rb.AddForce(new Vector2(0, Jump));
                    P2jump = true;
                }
                break;
            //6方向ジャンプ
            case 'c':
                if (player == 1)
                {
                    P1rb.AddForce(new Vector2(200, Jump));
                    P1jump = true;
                }
                else if (player == 2)
                {
                    P2rb.AddForce(new Vector2(200, Jump));
                    P2jump = true;
                }
                break;
            //4方向ジャンプ
            case 'z':
                if (player == 1)
                {
                    P1rb.AddForce(new Vector2(-200, Jump));
                    P1jump = true;
                }
                else if (player == 2)
                {
                    P2rb.AddForce(new Vector2(-200, Jump));
                    P2jump = true;
                }
                break;
            //1しゃがみ
            case 'q':
                if (player == 1)
                {
                    shit[0] = true;
                    if (!center1p) { guard[0] = true; Debug.Log("ガード1"); }
                }
                else if (player == 2)
                {
                    shit[1] = true;
                    if (!center2p) { guard[0] = true; Debug.Log("ガード2"); }
                }
                break;
            //2しゃがみ
            case 'd':
                if (player == 1)
                {
                    shit[0] = true;
                    Debug.Log(shit[0]);
                }
                else if (player == 2)
                {
                    shit[1] = true;
                }
                break;
            //3しゃがみ
            case 'e':
                if (player == 1)
                {
                    shit[0] = true;
                    if (center1p) { guard[0] = true; Debug.Log("ガード1"); }
                }
                else if (player == 2)
                {
                    shit[1] = true;
                    if (center2p) { guard[0] = true; Debug.Log("ガード2"); }
                }
                break;
            default:break;
        }
        //しゃがみのboolを判定してしゃがみ状態に
            if (standCollider[player-1].activeInHierarchy&&shit[player-1])
            {
                standCollider[player-1].SetActive(false);
                shitCollider[player-1].SetActive(true);
                image[player-1].sprite = shitSprite[player-1];
                Debug.Log("しゃがむ");
            }
            else if (shitCollider[player-1].activeInHierarchy&&!shit[player-1])
            {
                shitCollider[player-1].SetActive(false);
                standCollider[player-1].SetActive(true);
                image[player-1].sprite = defultSprite[player-1];
                Debug.Log("立つ");
            }
        
        //移動しているときは歩くアニメーション
        switch (command)
        {
            case 'r':
            case 'l':
                if (!walkCheck[player-1]) { walkCheck[player - 1] = true; }
                WalkingAnim(player);
                break;
            default:
                if (walkCheck[player - 1]){
                    walkCheck[player - 1] = false;
                    image[player - 1].sprite = defultSprite[player - 1];
                    nextWalk[player-1] = 0;
                    walkTime[player-1] = 0;
                }
                break;
        }
    }
    //歩きのアニメーションを表示する
    void WalkingAnim(int player)
    {
        walkTime[player - 1]++;
        if (walkTime[player - 1] <= 2) { return; }
        walkTime[player - 1] = 0;
        Sprite[] moveSprites = moveSprites1p;
        if (player == 1)
        {
            moveSprites = moveSprites1p;
        }
        else if(player == 2)
        {
            moveSprites = moveSprites2p;
        }
        image[player-1].sprite = moveSprites[nextWalk[player - 1]];
        if (nextWalk[player - 1] == moveSprites.Length - 1)
        {
            nextWalk[player - 1] = 0;
        }
        else
        {
            nextWalk[player - 1]++;
        }
    }
    //ジャンプのアニメーション
    void JumpAnim(int player)
    {
        if (jumpAnimEnd[player - 1]) { return; }
        walkTime[player - 1]++;
        if (walkTime[player - 1] <= 2) { return; }
        walkTime[player - 1] = 0;
        Sprite[] jumpSprites = jumpSprite1p;
        if(player == 1)
        {
            jumpSprites = jumpSprite1p;
        }
        else if(player == 2)
        {
            jumpSprites = jumpSprite2p;
        }
        image[player - 1].sprite = jumpSprites[nextWalk[player - 1]];
        if (nextWalk[player - 1] == jumpSprites.Length - 1)
        {
            nextWalk[player - 1] = 0;
            jumpAnimEnd[player - 1] = true;
        }
        else
        {
            nextWalk[player - 1]++;
        }

    }
    //KOのアニメーション
    void KOAnim(bool player)
    {
        int playernum = player ? 1 : 0;
        int vector = player ? 1 : -1;
        image[playernum].gameObject.transform.position += new Vector3(0.03f * vector, 0,0);
        walkTime[playernum]++;
        if (walkTime[playernum] <= 3) { return; }
        walkTime[playernum] = 0;
        Sprite[] kOSprites = kOSprite1p;
        if (player == false)
        {
            kOSprites = kOSprite1p;
        }
        else if (player == true)
        {
            kOSprites = kOSprite2p;
        }
        image[playernum].sprite = kOSprites[nextWalk[playernum]];
        if (nextWalk[playernum] == kOSprites.Length - 1)
        {
            nextWalk[playernum] = 0;
            kOanimeTime= false;
        }
        else
        {
            nextWalk[playernum]++;
        }


    }


    void AttackOccurrence(int attackNum , int player)
    {
        if (attack[player-1].AttackCheck) { return; }
        IEnumerator coroutine = attack[player-1].SetParamete(attackParameter[player-1][attackNum], attackCollider[player-1][attackNum],image[player-1],player - 1,missileDirection );
        StartCoroutine(coroutine);
    }

    void Step(float step, GameObject rb, bool move,int player)
    {
        if (!move) { return; }
        StartCoroutine(StepCoroutine(step, rb, move,player));
    }

    IEnumerator StepCoroutine(float step,GameObject rb,bool move,int player) {
        if (!move) { yield break; }
        if(player == 1) { move1P = false; }
        else if(player == 2) { move2P = false; }
        //yield return new WaitForSeconds(1.0f);
        int i = 0;
        while (i <= 10)
        {
            rb.transform.position += new Vector3(step,0,0);
            i++;
            yield return null;
        }
        //rb.AddForce(new Vector2(step, 0));
        if (player == 1) { move1P = true; }
        else if (player == 2) { move2P = true; }
    }


    public void HitAttack(int player, GameObject rb, bool move, int guagePow)
    {
        if (!move) { return; }
        StartCoroutine(HitAttackCoroutine(player,rb,move,guagePow));
    }

    IEnumerator HitAttackCoroutine(int player, GameObject rb, bool move, int guagePow)
    {
        if (!move) { yield break; }
        image[player - 1].sprite = damageSprite[player - 1];
        var vec = new Vector3(rb.transform.position.x, rb.transform.position.y,rb.transform.position.z - 9);
        var obj = Instantiate(effect, vec, Quaternion.identity);
        StatusManager.Instance.GuageUp(player, guagePow);
        if (player == 2) { move2P = false; }
        else if (player == 1) { move1P = false; }
        Debug.Log("Hit1P:" + move1P + "Hit2P:" + move2P);
        yield return new WaitForSeconds(1.0f);
        image[player - 1].sprite = defultSprite[player - 1];
        Debug.Log(player);
        Destroy(obj);
        if (player == 2) { PlayerManager.Instance.move2P = true; }
        else if (player == 1) { PlayerManager.Instance.move1P = true; }
    }

    public void GuardAttack(int player , bool move)
    {
        if (!move) { return; }
        StartCoroutine(GuardAttackCoroutine(player, move));
    }

    IEnumerator GuardAttackCoroutine(int player, bool move)
    {
        if (!move) { yield break; }
        image[player - 1].sprite = guardSprite[player - 1];
        if (player == 2) { PlayerManager.Instance.move2P = false; }
        else if (player == 1) { PlayerManager.Instance.move1P = false; }
        yield return new WaitForSeconds(1.0f);
        image[player - 1].sprite = defultSprite[player - 1];
        Debug.Log(player);
        if (player == 2) { PlayerManager.Instance.move2P = true; }
        else if (player == 1) { PlayerManager.Instance.move1P = true; }
    }


    public void GetPos() {
        p1Pos = Player1.transform.position;
        //Debug.Log(p1Pos+ "p1");
        p2Pos = Player2.transform.position;
        //Debug.Log(p2Pos+ "p2");

        centerPos = (p1Pos + p2Pos) / 2;
        //Debug.Log(centerPos + "まんなか？？");

        Center.transform.position = centerPos;
    }

    void CenterLook() {
        if (p1Pos.x > centerPos.x && !center1p)
        {
            Player1.transform.Rotate(new Vector3(0f, 180f, 0f));
            center1p = true;
        }
        else if (p1Pos.x < centerPos.x && center1p == true) {
            Player1.transform.Rotate(new Vector3(0f, 180f, 0f));
            center1p = false;
        }

        if (p2Pos.x < centerPos.x && !center2p)
        {
            Player2.transform.Rotate(new Vector3(0f, 180f, 0f));
            center2p = true;
        }
        else if (p2Pos.x > centerPos.x && center2p == true)
        {
            Player2.transform.Rotate(new Vector3(0f, 180f, 0f));
            center2p = false;
        }
    }

    IEnumerator OnePlayerCamera()
    {
        if (timeControl == true)
        {
            Time.timeScale = 0;
            Camera.Instance.OneDeathblowCamera();
        }
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0);
        timeControl = false;
        yield return new WaitForSecondsRealtime(0);
        Camera.Instance.NotTouchWall();
        yield return new WaitForSecondsRealtime(0);
        AttackOccurrence(6, 1);
    }
    IEnumerator TwoPlayerCamera()
    {
        if (timeControl == true)
        {
            Time.timeScale = 0;
            Camera.Instance.TwoDeathblowCamera();
        }
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0);
        timeControl = false;
        yield return new WaitForSecondsRealtime(0);
        Camera.Instance.NotTouchWall();
        yield return new WaitForSecondsRealtime(0);
        AttackOccurrence(6, 2);
    }

    void ReturnTitle()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
