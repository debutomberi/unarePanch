using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parsentMax : MonoBehaviour {
    float r = 0.75f;
    float g = 0;
    float b = 0;
    float z = 0.75f;

    float i = 0.01f;
    enum coler
    {
        r,rd,g,gd,b,bd
    }
    coler _coler;
	// Use this for initialization
	void Start () {
        _coler = coler.r;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public IEnumerator Rain(GameObject obj)
    {
        while (true)
        {
            GetComponent<Image>().color = new Color(r, g, b,z);
            switch (_coler)
            {
                case coler.r:
                    r += i;
                    z += 0.05f;
                    if (r >= 1f) _coler = coler.rd;
                    break;
                case coler.bd:
                    b -= i;
                    if (b <= 0) _coler = coler.g;
                    break;
                case coler.g:
                    g += i;
                    if (g >= 0.75f) _coler = coler.rd;
                    break;
                case coler.rd:
                    r -= i;
                    z -= 0.05f;
                    if (r <= 0.6f) _coler = coler.r;
                    break;
                case coler.b:
                    b += i;
                    if (b >= 0.75f) _coler = coler.gd;
                    break;
                case coler.gd:
                    g -= i;
                    if (g <= 0) _coler = coler.r;
                    break;
                
            }
            yield return null;
        }
    }
}
