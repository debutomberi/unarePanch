using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : SingletonMonoBehavior<PlayerSelect>{


    int Pselect;

    int a = 100;
    //public int b = 150;

    public int A { get{ return a; } }
    
    GameObject[] player = new GameObject[2];

    public GameObject[] Player
    {
        get{return player;}
        set{player = value;}
    }

    PlayerManager script;


	// Use this for initialization
	void Start ()
    {
        //DontDestroyOnLoad(Player);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

}
