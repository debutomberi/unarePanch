using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : SingletonMonoBehavior<SceneManagers> {
    public enum Scene
    {
        start,
        charaSelect,
        colerSelect,
        mainGame,
        result
    }
    public Scene scene;
    

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        scene = Scene.start;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSceneState()
    {
        switch (scene)
        {
            case Scene.start:
                scene = Scene.charaSelect;
                SceneManager.LoadScene("Select");
                break;
            case Scene.charaSelect:
                scene = Scene.colerSelect;
                break;
            case Scene.colerSelect:
                scene = Scene.mainGame;
                SceneManager.LoadScene("Main");
                break;
            case Scene.mainGame:
                scene = Scene.result;
                SceneManager.LoadScene("Result");
                break;
            case Scene.result:
                scene = Scene.start;
                SceneManager.LoadScene("Start");
                break;
        }
    }
    
    //かくしーんのloadSceneを関数で実装しゅる
}
