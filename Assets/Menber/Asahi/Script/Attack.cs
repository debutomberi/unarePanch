using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {

    //攻撃の処理
    public IEnumerator Technique(int[] flame,bool attack,Collider2D attackCollider){
        
        if (!attack){
            Debug.Log("attaCK!");
            attack = true;
            for (int i = 0; i < flame[0] - 1; i++)
            {
                yield return null;
            }

            //攻撃の発生
            attackCollider.gameObject.SetActive(true);
            yield return null;

            for (int i = 0; i < flame[1] - 1; i++)
            {
                yield return null;
            }

            //攻撃の停止
            attackCollider.gameObject.SetActive(false);
            yield return null;

            for (int i = 0; i < flame[2]; i++)
            {
                yield return null;
            }

            //攻撃の終了
            attack = false;
        }
    }

    public IEnumerator SetParamete(AttackTable paramete,bool attack ,Collider2D attackCollider) {
        int[] attackFlame = { 20, 20, 20 };
        attackFlame[0] = paramete.oFlame;
        attackFlame[1] = paramete.cFlame;
        attackFlame[2] = paramete.sFlame;

        return Technique(attackFlame, attack, attackCollider);
    }

}
