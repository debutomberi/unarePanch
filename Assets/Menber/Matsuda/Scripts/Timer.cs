using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField]private float time;//タイマー
    [SerializeField] private float downSpeed;//カウントを1減らすのにかかる時間
    [SerializeField] T t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime * downSpeed;
        string str = time.ToString("F0");
        t.TextUp(str);
	}
}
