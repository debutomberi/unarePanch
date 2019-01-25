using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEmanager : MonoBehaviour {

    [SerializeField]AudioClip[] clips;
    [SerializeField]AudioSource audioSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlaySE(int num)
    {
        audioSource.clip = clips[num];
        audioSource.Play();
    }
}
