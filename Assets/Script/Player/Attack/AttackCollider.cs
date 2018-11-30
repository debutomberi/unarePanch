using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    int guagePow =0;
    bool deathblow;
    bool missile;

    [SerializeField]
    float flySpeed = 2.0f;
    [SerializeField]
    float flyTime = 1.0f;
    float flyTimer = 0.0f;

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

    private void OnTriggerEnter2D(Collider2D collision){
        //必殺技は別の処理に投げる。
        if (deathblow) {
            OnDeathblowEnter(collision);
            return;
        }
        if (collision.gameObject.tag == "1P"&&!PlayerManager.Instance.Guard[0]) {
            Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
            PlayerManager.Instance.HitAttack(2, -300, rb2D, PlayerManager.Instance.Move1P,guagePow);
        }
        else if (collision.gameObject.tag == "2P"&& !PlayerManager.Instance.Guard[1]) {
            Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
            PlayerManager.Instance.HitAttack(1, 300, rb2D, PlayerManager.Instance.Move2P,guagePow);
        }
        UIManager.Instance.PageChenge();
    }
    
    //必殺技の処理
    void OnDeathblowEnter(Collider2D collision) {
        if(collision.gameObject.tag == "1P") {
            Debug.Log("2Pの勝ち！");
            UIManager.Instance.WinText(false);
        }
        else if (collision.gameObject.tag == "2P") {
            Debug.Log("1Pの勝ち！");
            UIManager.Instance.WinText(true);
        }
    }

    void FlyMissile(){
        transform.position += new Vector3(flySpeed*Time.deltaTime,0,0);
        flyTimer += Time.deltaTime;
        if(flyTime <= flyTimer) {
            gameObject.SetActive(false);
        }
    }
    
}
