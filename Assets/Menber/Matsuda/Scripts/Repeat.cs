using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour {
    [SerializeField]AudioSource MainAudio;
    [SerializeField] AudioSource SubAudio; 
    int i = 0;
    float time;
	// Update is called once per frame
	void Update () {
        if (!SubAudio.isPlaying)
        {
            time += Time.deltaTime;
            if (time >= 10)
            {
                time = 0;
                MainAudio.volume = 0.15f;
                SubAudio.Play();
            }
            else
            {
                MainAudio.volume = 1;
            }
        }
	}
}
