using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageText : MonoBehaviour
{ 
    [SerializeField]
    int maxDG = 100;

    [SerializeField]
    GameObject textObj;

    Text text;

    int onePgage;
    int twoPgage;

    public void Start()
    {
        Debug.Log("a");
        text = textObj.GetComponent<Text>();
        onePgage = StatusManager.Instance.DeathblowGuage[0];
        twoPgage = StatusManager.Instance.DeathblowGuage[1];

        text.text = onePgage.ToString();
        text.text = twoPgage.ToString();
    }
}
