using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : SingletonMonoBehavior<PlayerSelect> {


    int Pselect;

    public int a = 100;
    public int b;

    public int A { get{ return a; } }


    PlayerManager script;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            
        }
    }

    public void PlayerS()
    {
        a = 100;
        b = 200;
    }
}
