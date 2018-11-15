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
        Rigidbody2D rb2D = collision.transform.parent.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "1P") {
            StartCoroutine(HitAttack(1, -100, rb2D, PlayerManager.Instance.Move1P));
        }
        else if (collision.gameObject.tag == "2P") {
            StartCoroutine(HitAttack(2, 100, rb2D, PlayerManager.Instance.Move2P));
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

    IEnumerator HitAttack(int player,float value,Rigidbody2D rb,bool move) {
        rb.AddForce(new Vector2(value, 0));
        StatusManager.Instance.GuageUp(player, guagePow);
        move = false;
        yield return new WaitForSeconds(1.0f);
        move = true;
    }
}
