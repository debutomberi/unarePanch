using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    enum Controler
    {
        playerOne,
        playerTwe
    }
    [SerializeField] Controler controler;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        switch (controler)
        {
            case Controler.playerOne:
                if (Input.GetKeyDown("joystick 1 button 6"))
                {
                    Debug.Log("6 button");
                }
                if (Input.GetKeyDown("joystick 1 button 7"))
                {
                    Debug.Log("7 button");
                }break;
            case Controler.playerTwe:
                if (Input.GetKeyDown("joystick 2 button 6"))
                {
                    Debug.Log("6 button");
                }
                if (Input.GetKeyDown("joystick 2 button 7"))
                {
                    Debug.Log("7 button");
                }break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (controler)
        {
            case Controler.playerOne:
                if (Input.GetKeyDown("joystick 1 button 1"))
                {
                    Debug.Log("A");
                    if (collision.gameObject.tag == "2P") return;
                    Debug.Log(collision.gameObject.name);
                }
                break;
            case Controler.playerTwe:
                if (Input.GetKeyDown("joystick 2 button 1"))
                {
                    if (collision.gameObject.tag == "1P") return;
                    Debug.Log(collision.gameObject.name);
                }
                break;
        }
        
    }
}
