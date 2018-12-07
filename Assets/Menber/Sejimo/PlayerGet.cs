using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGet : MonoBehaviour {

    GameObject pget;

    PlayerSelect script;
    

    //Pselect = 0;

	// Use this for initialization
	void Start () {
        pget = GameObject.Find("pget");
        script =pget.GetComponent<PlayerSelect>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    int select = script.a;
        //    Debug.Log(select);
        //}


    }

    public void OnClick()
    {
        int select = PlayerSelect.Instance.a;
        //int select = script.a;
        Debug.Log(select);
    }


}
