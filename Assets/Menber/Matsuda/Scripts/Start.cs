using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("joystick 1 button 2"))
        {
            SceneManagers.Instance.ChangeSceneState();
        }
	}
}
