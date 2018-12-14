using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField]private float time;//タイマー
    [SerializeField] private float downSpeed;//カウントを1減らすのにかかる時間
    [SerializeField] T t;//テキスト変更をするscript
    bool isPlaying = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(TimerStart());
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator TimerStart()
    {
        while (isPlaying || time > 0)
        {
            time -= Time.deltaTime * downSpeed;
            string str = time.ToString("F0");
            t.TextUp(str);
            yield return null;
        }
        yield break;
    }
}
