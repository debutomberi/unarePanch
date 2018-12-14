using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMove : MonoBehaviour {
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] Vector2 x;
    [SerializeField] Vector2 y;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal2") >= 0.5)
        {
            MovePointer(point2,x);
        }
        if (Input.GetAxis("Vertical2") >= 0.5)
        {
            MovePointer(point2,y);
        }
        if (Input.GetAxis("Horizontal2")<= -0.5)
        {
            MovePointer(point2,-x);
        }
        if (Input.GetAxis("Vertical2") <= -0.5)
        {
            MovePointer(point2,-y);
        }
        if (Input.GetAxis("Horizontal") >= 0.5)
        {
            MovePointer(point1,x);
        }
        if (Input.GetAxis("Vertical") >= 0.5)
        {
            MovePointer(point1,y);
        }
        if (Input.GetAxis("Horizontal") <= -0.5)
        {
            MovePointer(point1,-x);
        }
        if (Input.GetAxis("Vertical") <= -0.5)
        {
            MovePointer(point1,-y);
        }
    }

    private void MovePointer(GameObject obj ,Vector3 i)
    {
        i = i / 10;
        obj.transform.position += i;
    }
}
