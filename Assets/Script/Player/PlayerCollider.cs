using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    public bool hit;
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.activeInHierarchy)
        {
            this.GetComponent<Rigidbody2D>().WakeUp();
        }
	}
}
