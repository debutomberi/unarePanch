﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ready_go : MonoBehaviour {

    public GameObject startgo = null;
    [SerializeField] SEmanager se;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Ready");
        startgo.GetComponent<Text>().enabled = true;
    }


    public IEnumerator Ready()
    {
        Time.timeScale = 0;
        UnityEngine.UI.Text text = startgo.GetComponent<UnityEngine.UI.Text>();
        text.text = "Ready";
        Debug.Log("ready");
        se.PlaySE(3);
        yield return new WaitForSecondsRealtime(2.0f);
        text.text = "Fight!";
        Debug.Log("go");
        se.PlaySE(4);
        yield return new WaitForSecondsRealtime(1.0f);
        text.text = "";
        yield return new WaitForSecondsRealtime(0f);
        Time.timeScale = 1;
    }


    // Update is called once per frame

}
