using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour{

    //攻撃の処理
    IEnumerator Technique(int[] flame, int flameCount,bool attack,Collider2D attackCollider){
        attack = true;

        for(int i = 0; i <flame[0]-1; i++) {
            yield return null;
        }

        //攻撃の発生
        yield return null;

        for(int i = 0; i <flame[1]-1; i++) {
            yield return null;
        }

        //攻撃の停止
        yield return null;

        for (int i = 0; i < flame[2]; i++){
            yield return null;
        }

        //攻撃の終了
        attack = false;

    }

}
