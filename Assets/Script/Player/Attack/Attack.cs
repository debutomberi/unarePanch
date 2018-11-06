using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {
    //独自で持っているbool
    bool attack;
    public int pow;

    //近接攻撃の処理
    public IEnumerator Technique(int[] flame,GameObject attackCollider){
            //Debug.Log("attack!");
            attack = true;
            for (int i = 0; i < flame[0] - 1; i++)
            {
                yield return null;
            }

            //攻撃の発生
            attackCollider.SetActive(true);
            yield return null;

            for (int i = 0; i < flame[1] - 1; i++)
            {
                yield return null;
            }

            //攻撃の停止
            attackCollider.SetActive(false);
            yield return null;

            for (int i = 0; i < flame[2]; i++)
            {
                yield return null;
            }

            //攻撃の終了
            attack = false;
            
        
    }

    //IEnumeratorを渡す関数
    public IEnumerator SetParamete(AttackTable paramete,GameObject attackCollider) {
        int[] attackFlame = { 20, 20, 20 };
        attackFlame[0] = paramete.oFlame;
        attackFlame[1] = paramete.cFlame;
        attackFlame[2] = paramete.sFlame;
        pow = paramete.power;

        return Technique(attackFlame,attackCollider);
    }

    //boolを渡す関数
    public bool attackCheck() {
        return attack;
    }
}
