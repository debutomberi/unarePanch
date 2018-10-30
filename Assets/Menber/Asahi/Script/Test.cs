using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : SingletonMonoBehavior<Test> {

    [SerializeField]
    int[] attackFlame = { 20, 20, 20 };
    [SerializeField]
    Collider2D attackCollider;

    bool nowAttack =true;

	// Use this for initialization
	void Start () {
        attackCollider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Attack attack = new Attack();
            IEnumerator coroutine = attack.Technique(attackFlame, nowAttack, attackCollider);
            StartCoroutine(coroutine);

        }
	}
}
