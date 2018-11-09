using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    int guagePow;

    public int GuagePow
    {
        get{
            return guagePow;
        }

        set{
            guagePow = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "1P") {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            StatusManager.Instance.GuageUp(1, guagePow);
        }
        else if (collision.gameObject.tag == "2P") {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
            StatusManager.Instance.GuageUp(2, guagePow);
        }
        else if(collision.gameObject.tag == "Attack") {
            if (transform.parent.tag == "1P"){
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
                transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
            }
            else if(transform.parent.tag == "2P") {
                collision.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
                transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            }

        }
    }
    
}
