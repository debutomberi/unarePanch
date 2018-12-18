using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : SingletonMonoBehavior<Camera> {

    GameObject mainCamera;
    GameObject center;
    Vector3 cp;
    Vector3 centerPos;

    bool fixation;

    PlayerManager script;
    void Start()
    {
        center = GameObject.Find("Center");
        mainCamera = GameObject.Find("Main Camera");
        fixation = false;
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    void CameraMove() {
        
        if (fixation == false)
        {
            cp = center.transform.position;
            centerPos = new Vector3(cp.x, 0, -10);
            mainCamera.transform.position = centerPos;
        }
        if (fixation == true) {
            Debug.Log("true");
        }


        //xが一定の値(x)に到達するとカメラを固定する
        if (mainCamera.transform.position.x >= 7) {
            mainCamera.transform.position = new Vector3(7, 0, -10);
        }
        //xが一定の値(-x)に到達するとカメラを固定する
        if (mainCamera.transform.position.x <= -7)
        {
            mainCamera.transform.position = new Vector3(-7, 0, -10);
        }
    }

    //public void TouchLeftWall(Collision2D collision)
    //{
    //    //左の壁に触れてるときにカメラを左に動かしていく
    //    mainCamera.transform.Translate(-1, 0, 0);
    //    Debug.Log("aaaa");
    //}
    //public void TouchRightWall(Collision2D collision)
    //{
    //    //右の壁に触れてるときにカメラを右に動かしていく
    //    mainCamera.transform.position += new Vector3(1, 0, -10);
    //    Debug.Log("bbbb");
    //}
    public void TouchTwoWall(Collision2D collsion)
    {
        //どちらの壁にも触れてるときカメラを動かないようにする
        fixation = true;
        Debug.Log("hogehoge");
    }
    public void NotTouchWall() {
        fixation = false;
        Debug.Log("fugafuga");
    }

}
