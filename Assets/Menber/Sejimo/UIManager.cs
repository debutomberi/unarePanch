using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{ 
    [SerializeField]
    int maxDG = 100;

    [SerializeField]
    GameObject[] textObj = new GameObject[2];

    Text[] text = new Text[2];

    int onePgage;
    int twoPgage;

    int onePwin;
    int twoPwin;

    public void Start()
    {
        //Debug.Log("a");
        
        for(int i =0; i <textObj.Length;i++)
        {
            text[i] = textObj[i].GetComponent<Text>();
        }
        PageChenge();
    }

    public void PageChenge() {
        onePgage = StatusManager.Instance.DeathblowGuage[0];
        twoPgage = StatusManager.Instance.DeathblowGuage[1];

        text[0].text = onePgage.ToString();
        text[1].text = twoPgage.ToString();
    }
}
