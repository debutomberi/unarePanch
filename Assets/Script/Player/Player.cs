using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    int playerID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor") {
            PlayerManager.Instance.OnPlayerCollisionEnter(playerID, collision);
        }
        
    }
}
