using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{

    [SerializeField] private float time;//タイマー
    [SerializeField] private float downSpeed;//カウントを1減らすのにかかる時間
    bool isPlaying = false;//play画面かどうか

    [SerializeField]
    int maxDG = 100;

    [SerializeField]
    GameObject[] textObj = new GameObject[2];

    Text[] text = new Text[2];
    PopChamge[] pop = new PopChamge[2];
    //Text[] wtest = new Text[2];

    int onePgage;
    int twoPgage;

    [SerializeField]
    GameObject wintext;
    Text _wimtext;
    [SerializeField]
    Text timerText;
    //数値の画像
    [SerializeField] Sprite[] spr;
    //画像を表示するImage
    [SerializeField] Image[] image;

    public void Start()
    {
        
        for(int i =0; i <textObj.Length;i++)
        {
            text[i] = textObj[i].GetComponent<Text>();
            pop[i] = textObj[i].GetComponent<PopChamge>();
        }
        PageChenge();

        //WinText(false);
        StartCoroutine(TimerStart());
    }

    public void PageChenge() {
        onePgage = StatusManager.Instance.DeathblowGuage[0];
        twoPgage = StatusManager.Instance.DeathblowGuage[1];

        text[0].text = onePgage.ToString();
        pop[0].StartAction();
        text[1].text = twoPgage.ToString();
        pop[1].StartAction();
    }

    public void WinText(bool isWin) {
        _wimtext = wintext.GetComponent<Text>();
        _wimtext.text = (isWin)? "1Player Win!\nBまたは3ボタンでリザルト画面へ" : "2Player Win!\nBまたは3ボタンでリザルト画面へ";
        PlayerManager.Instance.isPlaying = false;
        //if (isWin)
        //{
        //    _wimtext.text = "1Player Win!";
        //}
        //else
        //{
        //    _wimtext.text = "2Player Win!";
        //}
    }

    public IEnumerator TimerStart()
    {
        while (isPlaying || time > 0)
        {
            time -= Time.deltaTime * downSpeed;
            timerText.text = time.ToString("F0");
            yield return null;
        }
        yield break;
    }

    public void NumToSpr(int num)
    {
        string numStr = num.ToString();
        for (int i = 0; i < numStr.Length; i++)
        {
            string a = numStr.Substring(i, i);
            int b = int.Parse(a);
            image[i].sprite = spr[b];
        }
    }
}
