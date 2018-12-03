using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {
    //独自で持っているbool
    bool attackCheck;
    public int pow;

    bool db;
    bool msl;
    public bool AttackCheck{
        get{ return attackCheck;}
    }

    //近接攻撃の処理
    public IEnumerator Technique(int[] flame,GameObject attackCollider,SpriteRenderer player,float time=1.0f){
        //Debug.Log("attack!");
        attackCheck = true;
        for (int i = 0; i < flame[0] - 1; i++){
            yield return null;
        }

        var attackColliderScript = attackCollider.GetComponent<AttackCollider>();
        //攻撃の発生。発生時に飛び道具かと必殺技かを持たせる。
        attackColliderScript.Deathblow = db;        
        attackColliderScript.Missile = msl;
        //飛び道具のときは専用のステータスを組む。
        if (msl) {
            attackColliderScript.FlyTime = time;
            attackColliderScript.FirstColliderPoint = attackCollider.transform.position;
        }
        attackCollider.SetActive(true);
        //Debug.Log(pow);    
        player.sprite = Resources.Load("Images/斜め横　パピヨンEX 差分", typeof(Sprite)) as Sprite;
        attackColliderScript.GuagePow = pow;
        yield return null;

        for (int i = 0; i < flame[1] - 1; i++){
            yield return null;
        }

        //攻撃の停止
        if (!msl) { attackCollider.SetActive(false); }
        yield return null;

        for (int i = 0; i < flame[2]; i++){
            yield return null;
        }

        //攻撃の終了
        player.sprite = Resources.Load("Images/パピヨンEX", typeof(Sprite)) as Sprite;
        attackCheck = false;
            
        
    }

    //IEnumeratorを渡す関数
    public IEnumerator SetParamete(AttackTable paramete,GameObject attackCollider,SpriteRenderer player) {
        int[] attackFlame = { 20, 20, 20 };
        attackFlame[0] = paramete.oFlame;
        attackFlame[1] = paramete.cFlame;
        attackFlame[2] = paramete.sFlame;
        float time = paramete.flyTime;
        pow = paramete.power;
        db = paramete.deathblow;
        msl = paramete.missile;
        return Technique(attackFlame,attackCollider,player, time);
    }

    
}
