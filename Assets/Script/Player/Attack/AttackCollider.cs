using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    int guagePow =0;
    bool deathblow;
    bool missile;

    //飛ぶスピード
    [SerializeField]
    float flySpeed = 2.0f;
    //飛ぶ時間
    [SerializeField]
    float flyTime = 1.0f;
    float flyTimer = 0.0f;
    //飛び道具初期位置
    Vector3 firstColliderPoint;
    GameObject player;

    public int GuagePow{
        get{return guagePow;}
        set{guagePow = value;}
    }
    public bool Deathblow{
        get{return deathblow;}
        set{deathblow = value;}
    }
    public bool Missile{
        get{return missile;}
        set{missile = value;}
    }
    public float FlyTime{
        get{return flyTime;}
        set{ flyTime = value;}
    }
    public Vector3 FirstColliderPoint{
        get{return firstColliderPoint;}
        set{firstColliderPoint = value;}
    }

    private void Update(){
        if (missile & transform.parent) {
            SetPoint();
        }
        else if(missile) { FlyMissile(); }
    }

    private void SetPoint() {
        player = transform.parent.gameObject;
        this.gameObject.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //必殺技は別の処理に投げる。
        if (deathblow) {
            OnDeathblowEnter(collision);
            return;
        }
        if (collision.gameObject.tag == "1P"&&!PlayerManager.Instance.Guard[0]) {
            //Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
            PlayerManager.Instance.HitAttack(2, -0.1f, collision.gameObject, PlayerManager.Instance.Move1P,guagePow);
            //var audio = GetComponent<AudioSource>();
            //audio.Play();
        }
        else if (collision.gameObject.tag == "1P" && !PlayerManager.Instance.Guard[0]){
            PlayerManager.Instance.GuardAttack(2, PlayerManager.Instance.Move1P);
        }
        else if (collision.gameObject.tag == "2P"&& !PlayerManager.Instance.Guard[1]) {
            //Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
            PlayerManager.Instance.HitAttack(1, 0.1f, collision.gameObject, PlayerManager.Instance.Move2P,guagePow);
            //var audio = GetComponent<AudioSource>();
            //audio.Play();
        }
        else if (collision.gameObject.tag == "2P" && !PlayerManager.Instance.Guard[1]){
            PlayerManager.Instance.GuardAttack(1, PlayerManager.Instance.Move2P);
        }
        UIManager.Instance.PageChenge();
    }
    
    //必殺技の処理
    void OnDeathblowEnter(Collider2D collision)
    {
        var audio = GetComponent<AudioSource>();
        //audio.Play();
        if (collision.gameObject.tag == "1P") {
            Debug.Log("2Pの勝ち！");
            StartCoroutine(DeathblowCoroutine(false));
        }
        else if (collision.gameObject.tag == "2P") {
            Debug.Log("1Pの勝ち！");
            StartCoroutine(DeathblowCoroutine(true));
        }
    }

    void FlyMissile(){
        int direction = PlayerManager.Instance.missileDirection;
        transform.position += new Vector3(flySpeed*direction*Time.deltaTime,0,0);
        flyTimer += Time.deltaTime;
        if(FlyTime <= flyTimer) {
            this.gameObject.transform.parent = player.transform;
            transform.position = firstColliderPoint;
            missile = false;
            gameObject.SetActive(false);
            flyTimer = 0;
        }
    }
    
    IEnumerator DeathblowCoroutine(bool Playernum){
        UIManager.Instance.WinText(Playernum);
        PlayerManager.Instance.kOPlayer = Playernum;
        PlayerManager.Instance.kOanimeTime = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 1.0f;
    }

}
