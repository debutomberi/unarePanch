﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T : MonoBehaviour {
    [SerializeField]Text text;
	// Use this for initialization
	void Start () {
        //text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TextUp(string str)
    {
        text.text = str;
    }
}