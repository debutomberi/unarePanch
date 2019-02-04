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

    bool p1gageMax = false;
    bool p2gageMax = false;

    [SerializeField]
    Slider _1pslider;
    [SerializeField]
    Image _1pimage;
    [SerializeField]
    Slider _2pslider;
    [SerializeField]
    Image _2pimage;
    [SerializeField]
    GameObject _1psliderImage;
    [SerializeField]
    GameObject _2psliderImage;

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
            //pop[i] = textObj[i].GetComponent<PopChamge>();
        }
        PageChenge();

        //WinText(false);
        StartCoroutine(TimerStart());
    }

    public void PageChenge() {
        onePgage = StatusManager.Instance.DeathblowGuage[1];
        twoPgage = StatusManager.Instance.DeathblowGuage[0];
        if(onePgage == 0)
        {
            StartCoroutine(_1pslider.GetComponent<parsentMax>().UseGage());
        }
        else
        {
            _1pslider.value = onePgage;
        }
        if(twoPgage == 0)
        {
            StartCoroutine(_2pslider.GetComponent<parsentMax>().UseGage());
        }
        else
        {
            _2pslider.value = twoPgage;
        }
        if(_1pslider.value == 100)
        {
            _1psliderImage.SetActive(true);
            text[0].text = onePgage.ToString();
            if (!p1gageMax)
            {
                p1gageMax = true;
                StartCoroutine(_1pslider.GetComponent<parsentMax>().MaxParsent(_1psliderImage));
            }
        }
        else
        {
            if (_1psliderImage.activeSelf)
            {
                _1psliderImage.SetActive(false);
                p1gageMax = false;
                StopCoroutine(_1pslider.GetComponent<parsentMax>().MaxParsent(_1psliderImage));
            }
        }
        if(_2pslider.value == 100)
        {
            
            _2psliderImage.SetActive(true);
            text[1].text = twoPgage.ToString();
            if (!p2gageMax)
            {
                p2gageMax = true;
                StartCoroutine(_2psliderImage.GetComponent<parsentMax>().MaxParsent(_2psliderImage));
            }
        }
        else
        {
            if (_2psliderImage.activeSelf)
            {
                _2psliderImage.SetActive(false);
                p2gageMax = false;
                StopCoroutine(_2psliderImage.GetComponent<parsentMax>().MaxParsent(_2psliderImage));
            }
        }

        text[0].text = onePgage.ToString();
        //pop[0].StartAction();
        text[1].text = twoPgage.ToString();
        //pop[1].StartAction();
    }

    public void WinText(bool isWin) {
        _wimtext = wintext.GetComponent<Text>();
        _wimtext.text = isWin?"1Player Win!\nBまたは3ボタンでリザルト画面へ" : "2Player Win!\nBまたは3ボタンでリザルト画面へ";
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
