using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision){
        var test = transform.parent.GetComponent<Test>();
        test.hit();
    }

    private void OnCollisionStay2D(Collision2D collision){
        
    }
}
