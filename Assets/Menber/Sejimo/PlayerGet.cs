using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGet : MonoBehaviour {

    [SerializeField]
    int PlayerID = 1;

    [SerializeField]
    GameObject pget;

    PlayerSelect script;
    

    //Pselect = 0;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnClick()
    {
        PlayerSelect.Instance.Player[PlayerID-1] = pget;
    }


}
