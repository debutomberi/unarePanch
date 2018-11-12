using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChange : SingletonMonoBehavior<StatusManager>
{
    [SerializeField]
    int maxDG = 100;

    [SerializeField]
    GameObject textObj;

    Text text;
    int onePgage;

    private void Start()
    {
        Debug.Log("a");
        text = textObj.GetComponent<Text>();
        onePgage = StatusManager.Instance.DeathblowGuage[0];

        text.text = onePgage.ToString();
    }
}
