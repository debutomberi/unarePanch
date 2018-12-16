using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberToSprite : MonoBehaviour {

    [SerializeField] Sprite[] spr;
    [SerializeField] Image[] image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// intで渡した数値を調べて,spriteに数値の画像をぶち込む処理
    /// </summary>
    /// <param name="num"></param>
    public void NumToSpr(int num)
    {
        string numStr = num.ToString();
        for(int i = 0;i < numStr.Length; i++)
        {
            string a = numStr.Substring(i, i);
            int b = int.Parse(a);
            image[i].sprite = spr[b];
        }
    }
}
