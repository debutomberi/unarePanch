using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGet : MonoBehaviour {

    [SerializeField]
    int PlayerID = 1;

    [SerializeField]
    GameObject pget;    // Inspector上に1Pのキャラクターを入れる

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
        // PlayerSelect.csのPlayer関数を呼び出して1Pをsetする。
        PlayerSelect.Instance.Player[PlayerID-1] = pget;
    }


}
