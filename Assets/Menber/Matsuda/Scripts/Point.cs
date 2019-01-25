using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    enum Controler
    {
        playerOne,
        playerTwe
    }

    [SerializeField] SelectCharas _select;
    [SerializeField] Controler controler;
    

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
                        _select.ReSelect(1);
                        Debug.Log("P1 2 button");
                    }
                    break;
                case Controler.playerTwe:
                    
                    if (Input.GetKeyDown("joystick 2 button 1"))
                    {
                        _select.ReSelect(2);
                        Debug.Log("P2 2 button");
                    }
                    break;
            }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (controler)
        {
            case Controler.playerOne:
                if (Input.GetKeyDown("joystick 1 button 2"))
                {
                    _select.ChoisChara(collision, 1);
                }
                break;
            case Controler.playerTwe:
                if (Input.GetKeyDown("joystick 2 button 2"))
                {
                    _select.ChoisChara(collision, 2);
                }
                break;
        }
        
    }
}
