using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : SingletonMonoBehavior<PlayerSelect> {

    //int oneP;

    //int twoP;

    int player1;
    int player2;

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
            //player1 = GameObject.Find("player1");
           // player1 = PlayerManager.Instance.attackColliderOnePlayer;

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //player2 = GameObject.Find("player1");
            //player2 = PlayerManager.Instance.;
        }
    }

    public void PlayerS()
    {
        //oneP = PlayerManager.

        //twoP = PlayerManager.
    }
}
