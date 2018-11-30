using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : SingletonMonoBehavior<Camera> {

    GameObject mainCamera;
    GameObject center;
    Vector3 cp;
    Vector3 centerPos;


    PlayerManager script;
    void Start()
    {
        center = GameObject.Find("Center");
        mainCamera = GameObject.Find("Main Camera");
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    void CameraMove() {
        cp = center.transform.position;
 
        centerPos = new Vector3(cp.x, 0, -10);
        mainCamera.transform.position = centerPos;
        
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
}
