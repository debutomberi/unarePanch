using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    public bool hit = false;
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.transform.parent.GetComponent<Rigidbody2D>().WakeUp();
            if (hit) { StartCoroutine(HitUp()); }
        }
	}

    IEnumerator HitUp()
    {
        yield return new WaitForSeconds(0.6f);
        hit = false;
    }
}
