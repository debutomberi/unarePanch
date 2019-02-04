using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parsentMax : MonoBehaviour {
    float r = 0.75f;
    float g = 0;
    float b = 0;
    float z = 0.75f;

    float speed = 0.01f;
    bool col = true;

    bool isGageDown = true;
    [SerializeField]Image img;
    [SerializeField]Slider slider;
    
    public IEnumerator MaxParsent(GameObject obj)
    {
        while (true)
        {
            img.color = new Color(r, g, b,z);
            if (col)
            {
                r += speed;
                z += 0.05f;
                if (r >= 1f) col = false;
            }
            else
            {
                r -= speed;
                z -= 0.05f;
                if (r <= 0.6f) col = true;
            }
            
            yield return null;
        }
    }
    public IEnumerator UseGage()
    {
        isGageDown = true;
        while (isGageDown)
        {
            slider.value -= 1;
            if (slider.value == 0) isGageDown = false;
            yield return null;
        }
    }
}
