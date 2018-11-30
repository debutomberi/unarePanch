using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehavior<SceneManager> {
    public enum Scene
    {
        start,
        charaSelect,
        colerSelect,
        mainGame,
    }
    public Scene scene;
	// Use this for initialization
	void Start () {
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
                break;
            case Scene.charaSelect:
                break;
            case Scene.colerSelect:
                break;
            case Scene.mainGame:
                break;
        }
    }
    //かくしーんのloadSceneを関数で実装しゅる
}
