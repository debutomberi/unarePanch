using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {

    //int oneP;

    //int twoP;

    GameObject player1;
    GameObject player2;

    PlayerManager script;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void OnClick(int select)
    //{
    //    switch (select)
    //    {
    //        case 0:
    //           // Debug.Log;
    //            break;

    //        case 1:
    //           // Debug.Log;
    //            break;
    //    }
    //}

    void select ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player1 = GameObject.Find("player1");
           // script = player1.GetComponent<PlayerManager.Player1>();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            player2 = GameObject.Find("player1");
          //  script = player1.GetComponent<PlayerManager.Player2>();
        }
    }

    public void PlayerS()
    {
        //oneP = PlayerManager.

        //twoP = PlayerManager.
    }
}
