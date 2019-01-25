using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : SingletonMonoBehavior<Camera> {

    GameObject mainCamera;
    GameObject center;

    GameObject onePlayer;
    GameObject twoPlayer;

    Vector3 cp;
    Vector3 centerPos;

    Vector3 onePos;
    Vector3 twoPos;

    Camera Cam;
    float camSize;

    bool fixation;

    PlayerManager script;
    void Start()
    {
        center = GameObject.Find("Center");
        mainCamera = GameObject.Find("Main Camera");
        onePlayer = GameObject.Find("Player1");
        twoPlayer = GameObject.Find("Player2");
        fixation = false;
        Cam = mainCamera.GetComponent<Camera>();
        
    }

    private void Update()
    {
        CameraMove();
        GetPlayerPos();
    }

    void GetPlayerPos()
    {
        onePos = onePlayer.transform.position;
        twoPos = twoPlayer.transform.position;
        onePos.z = -10;
        twoPos.z = -10;
    }
    public void CameraMove() {
        
        if (fixation == false)
        {
            cp = center.transform.position;
            centerPos = new Vector3(cp.x, 0, -10);
            mainCamera.transform.position = centerPos;
        }
        


        //xが一定の値(x)に到達するとカメラを固定する
        if (mainCamera.transform.position.x >= 5) {
            mainCamera.transform.position = new Vector3(5, 0, -10);
        }
        //xが一定の値(-x)に到達するとカメラを固定する
        if (mainCamera.transform.position.x <= -5)
        {
            mainCamera.transform.position = new Vector3(-5, 0, -10);
        }
    }
    public void TouchTwoWall(Collision2D collsion)
    {
        //どちらの壁にも触れてるときカメラを動かないようにする
        fixation = true;
    }
    public void NotTouchWall() {
        fixation = false;
    }
    public void OneDeathblowCamera()
    {
        mainCamera.transform.position = onePos;
        fixation = true;
     }
    public void TwoDeathblowCamera()
    {
        mainCamera.transform.position = twoPos;
        fixation = true;
    }

}
