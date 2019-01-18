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

    //攻撃の処理
    public IEnumerator Technique(int[] flame,GameObject attackCollider,SpriteRenderer player,Sprite[] attackSprite,float time=1.0f){
        //攻撃発生までの猶予
        attackCheck = true;
        player.sprite = attackSprite[1];

        for (int i = 0; i <= flame[0]/2; i++){
            yield return null;
        }
        player.sprite = attackSprite[2];

        for (int i = 0; i <= flame[0]/2; i++){
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
        //player.sprite = Resources.Load("Images/斜め横　パピヨンEX 差分", typeof(Sprite)) as Sprite;
        player.sprite = attackSprite[3];
        attackColliderScript.GuagePow = pow;
        yield return null;

        for (int i = 0; i <= flame[1]/2; i++){
            yield return null;
        }
        player.sprite = attackSprite[4];

        for (int i = 0; i <= flame[1]/2; i++){
            yield return null;
        }

        //攻撃の停止
        if (!msl) { attackCollider.SetActive(false); }
        player.sprite = attackSprite[5];
        yield return null;

        for (int i = 0; i <= flame[2]/2; i++){
            yield return null;
        }
        player.sprite = attackSprite[6];

        for (int i = 0; i <= flame[2]/2; i++){
            yield return null;
        }

        //攻撃の終了
        //player.sprite = Resources.Load("Images/パピヨンEX", typeof(Sprite)) as Sprite;
        player.sprite = attackSprite[7];
        attackCheck = false;
            
        
    }

    //IEnumeratorを渡す関数
    public IEnumerator SetParamete(AttackTable paramete,GameObject attackCollider,SpriteRenderer player,int playerNum) {
        int[] attackFlame = { 20, 20, 20 };
        attackFlame[0] = paramete.oFlame;
        attackFlame[1] = paramete.cFlame;
        attackFlame[2] = paramete.sFlame;
        float time = paramete.flyTime;
        pow = paramete.power;
        db = paramete.deathblow;
        msl = paramete.missile;
        if (paramete.AttackSprite.Length != 8) { Debug.LogError("攻撃のスプライトの数が違います。"); return null; }
            Sprite[] Sprites = paramete.AttackSprite;
            return Technique(attackFlame, attackCollider, player, Sprites, time);
       
    }

    
}
