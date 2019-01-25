using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    int playerID;

    bool oneTouchWall;
    Rigidbody2D rg2d;
	// Use this for initialization
	void Start () {
        oneTouchWall = false;
        rg2d = GetComponent<Rigidbody2D>();
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
        if(collision.gameObject.name == "Player1" && PlayerManager.Instance.P2jump && this.transform.position.y - collision.gameObject.transform.position.y >= 3.5f|| collision.gameObject.name == "Player2" && PlayerManager.Instance.P1jump && this.transform.position.y - collision.gameObject.transform.position.y >= 3.5f)
        {
            rg2d.AddForce(new Vector2(rg2d.velocity.x,200));
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
