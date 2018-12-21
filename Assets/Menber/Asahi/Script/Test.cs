using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : SingletonMonoBehavior<Test> {

    [SerializeField]
    List<GameObject> attackCollider = new List<GameObject>();
    [SerializeField]
    List<AttackTable> attackParameter = new List<AttackTable>();
    [SerializeField]
    SpriteRenderer image;

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
        if (attack.AttackCheck) { return; }
       // IEnumerator coroutine = attack.SetParamete(attackParameter[AttackNum],attackCollider[AttackNum],image);
       // StartCoroutine(coroutine);
    }


}
