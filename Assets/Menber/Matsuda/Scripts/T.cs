using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T : MonoBehaviour {
    [SerializeField]Text text;
    RectTransform rect;
	// Use this for initialization
	void Start () {
        //text = this.GetComponent<Text>();
        rect = GetComponent<RectTransform>();
        Method();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TextUp(string str)
    {
        text.text = str;
    }
    private void Method()
    {
        /*
        var localscale = rect.localScale;
        var scaleX = localscale.x;
        scaleX = Mathf.Lerp(1, 5, 5);
        localscale.x = scaleX;
        localscale.y = scaleX;
        rect.localScale = localscale;
        */
    }
}
