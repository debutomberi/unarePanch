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
    public IEnumerator Technique(int[] flame,GameObject attackCollider){
        //Debug.Log("attack!");
        attackCheck = true;
        for (int i = 0; i < flame[0] - 1; i++){
            yield return null;
        }

        //攻撃の発生。種類によって処理を分ける。
        if(db){
            attackCollider.SetActive(true);
            var attackColliderScript = attackCollider.GetComponent<AttackCollider>();
            attackColliderScript.Deathblow = db;
        }
        else if (msl) {
            Debug.Log("攻撃を飛ばした！");
        }else{
            attackCollider.SetActive(true);
            var attackColliderScript = attackCollider.GetComponent<AttackCollider>();
            //Debug.Log(pow);
            attackColliderScript.GuagePow = pow;
        }
        yield return null;

        for (int i = 0; i < flame[1] - 1; i++){
            yield return null;
        }

        //攻撃の停止
        attackCollider.SetActive(false);
        yield return null;

        for (int i = 0; i < flame[2]; i++){
            yield return null;
        }

        //攻撃の終了
        attackCheck = false;
            
        
    }

    //IEnumeratorを渡す関数
    public IEnumerator SetParamete(AttackTable paramete,GameObject attackCollider) {
        int[] attackFlame = { 20, 20, 20 };
        attackFlame[0] = paramete.oFlame;
        attackFlame[1] = paramete.cFlame;
        attackFlame[2] = paramete.sFlame;
        pow = paramete.power;
        db = paramete.deathblow;
        msl = paramete.missile;
        return Technique(attackFlame,attackCollider);
    }

    
}
