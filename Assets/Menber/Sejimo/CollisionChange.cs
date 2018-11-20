using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChange : MonoBehaviour{

    // Use this for initialization
    void FixedUpdate()
    {
        Transform myTransform = this.transform;
        Vector2 pos = myTransform.position;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.localScale += new Vector3(0, -0.5f, 0);
            pos.y += -0.5f;

            myTransform.position = pos;
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.transform.localScale = new Vector2(0, 1);
        }
    }
}
