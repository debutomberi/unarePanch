using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision){
        var test = transform.parent.GetComponent<Test>();
        test.hit();
    }
    
}
