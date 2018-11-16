using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    int guagePow =0;
    bool deathblow;
    public int GuagePow{
        get{return guagePow;}
        set{guagePow = value;}
    }

    public bool Deathblow{
        get{return deathblow;}
        set{deathblow = value;}
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //必殺技は別の処理に投げる。
        if (deathblow) {
            OnDeathblowEnter(collision);
            return;
        }
        if (collision.gameObject.tag == "1P") {
            Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
            PlayerManager.Instance.HitAttack(2, -300, rb2D, PlayerManager.Instance.Move1P,guagePow);
        }
        else if (collision.gameObject.tag == "2P") {
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

    
}
