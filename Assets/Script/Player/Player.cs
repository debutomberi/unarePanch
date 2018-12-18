using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    int playerID;

    bool oneTouchWall;
	// Use this for initialization
	void Start () {
        oneTouchWall = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision){
        //ジャンプの処理
        if(collision.gameObject.tag == "Floor") {
            PlayerManager.Instance.OnPlayerCollisionEnter(playerID, collision);
        }

        //壁に触れているときのカメラの処理
        if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
        {
            oneTouchWall = true;
        }
       
        if (collision.gameObject.name == "LeftWall" && oneTouchWall == true || collision.gameObject.name == "RightWall" && oneTouchWall == true)
        {
            Camera.Instance.TouchTwoWall(collision);
        }

    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
        {
            oneTouchWall = false;
            Camera.Instance.NotTouchWall();
        }
        

    }
}
