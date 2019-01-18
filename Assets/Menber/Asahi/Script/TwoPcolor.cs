using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPcolor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float changeRed = 1.0f;
        float changeGreen = 1.0f;
        float cahngeBlue = 1.0f;
        float cahngeAlpha = 1.0f;
        // 元の画像がそのまま表示される。
        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
