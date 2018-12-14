using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Aボタンで選択");
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("joystick 2 button 1"))
        {
            if (collision.gameObject.tag == "2P" || collision.gameObject.tag == "1P") return;
            Debug.Log(collision.gameObject.name);
            Debug.Log("A");
        }
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            if (collision.gameObject.tag == "2P" || collision.gameObject.tag == "1P") return;
            Debug.Log(collision.gameObject.name);
            //Debug.Log("A");
        }
    }
}
