using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : SingletonMonoBehavior<Test> {

    [SerializeField]
    List<GameObject> attackCollider = new List<GameObject>();
    [SerializeField]
    List<AttackTable> attackParameter = new List<AttackTable>();

    bool nowAttack =false;
    int nowAttackNum;

    Attack attack = new Attack();

    // Use this for initialization
    void Start () {
        for(int i = 0; i <= attackCollider.Count-1; i++) {
            attackCollider[i].gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Z)) {
            Attack(0);
        }
	}

    void Attack(int AttackNum) {
        nowAttack = attack.attackCheck();
        if (nowAttack) { return; }
        IEnumerator coroutine = attack.SetParamete(attackParameter[AttackNum],attackCollider[AttackNum]);
        StartCoroutine(coroutine);
        nowAttackNum = AttackNum;
    }

    public void hit(){

        //Debug.Log(attackParameter[nowAttackNum].power);
        StatusManager.Instance.GuageUp(1, attack.pow);

    } 

}
