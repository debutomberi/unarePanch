using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : SingletonMonoBehavior<Test> {

    [SerializeField]
    List<Collider2D> attackCollider = new List<Collider2D>();
    [SerializeField]
    List<AttackTable> attackParameter = new List<AttackTable>();

    bool nowAttack =false;

	// Use this for initialization
	void Start () {
        for(int i = 0; i <= attackCollider.Count-1; i++) {
            attackCollider[i].gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)&&!nowAttack) {
            Attack(0);
        }
	}

    void Attack(int AttackNum) {
        Attack attack = new Attack();
        IEnumerator coroutine = attack.SetParamete(attackParameter[AttackNum],nowAttack,attackCollider[AttackNum]);
        StartCoroutine(coroutine);
    }
}
