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

    [SerializeField] SpriteRenderer _1pSpr;
    [SerializeField] SpriteRenderer _2pSpr;
    bool select1p = false;
    bool select2p = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        switch (controler)
        {
            case Controler.playerOne:
                if (Input.GetKeyDown("joystick 1 button 1"))
                {
                    Debug.Log("P1 1 button");
                }
                if (Input.GetKeyDown("joystick 1 button 2"))
                {
                    Debug.Log("P1 2 button");
                }break;
            case Controler.playerTwe:
                if (Input.GetKeyDown("joystick 2 button 1"))
                {
                    Debug.Log("P2 1 button");
                }
                if (Input.GetKeyDown("joystick 2 button 2"))
                {
                    Debug.Log("P2 2 button");
                }break;
        }
    }

    private void selectChara()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (controler)
        {
            case Controler.playerOne:
                if (Input.GetKeyDown("joystick 1 button 2"))
                {
                    if (collision.gameObject.tag == "2P") return;
                    Debug.Log(collision.gameObject.name);
                    var _spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
                    _1pSpr.sprite = _spriteRenderer.sprite;
                    select1p = true;
                }
                break;
            case Controler.playerTwe:
                if (Input.GetKeyDown("joystick 2 button 2"))
                {
                    if (collision.gameObject.tag == "1P") return;
                    Debug.Log(collision.gameObject.name);
                    var _spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
                    _1pSpr.sprite = _spriteRenderer.sprite;
                    select1p = true;
                }
                break;
        }
        
    }
}
