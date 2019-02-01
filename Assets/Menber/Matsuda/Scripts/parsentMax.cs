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
        r,rd
    }
    coler _coler = coler.r;
	
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
                case coler.rd:
                    r -= i;
                    z -= 0.05f;
                    if (r <= 0.6f) _coler = coler.r;
                    break;
                
            }
            yield return null;
        }
    }
}
