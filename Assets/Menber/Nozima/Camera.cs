using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : SingletonMonoBehavior<Camera> {

    GameObject Maincamera;
    GameObject Center;
    Vector3 CenterPos;
    void Start()
    {
        Center = GameObject.Find("Center");
        Maincamera = GameObject.Find("Main Camera");
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    void CameraMove() {
        /*
        これだとカメラの位置がおかしくなる
        CenterPos = Center.transform.position;
        Maincamera.transform.position = CenterPos;
        */

    }
}
