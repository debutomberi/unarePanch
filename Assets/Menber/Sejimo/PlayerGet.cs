using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerGet : ScriptableObject {

    [SerializeField]
    [Header("キャラクターID")]
    private int m_charaID;      // ID
    [SerializeField]
    [Header("スピード")]
    private int Speed;        // スピード
    [SerializeField]
    [Header("ジャンプ力")]
    private int Jump;         // ジャンプ力
                              // 攻撃表
    [SerializeField]
    [Header("攻撃の当たり判定")]
    public List<Sprite> at_Lists = new List<Sprite>();
    public List<Sprite> Getat_Lists()
    {
        return at_Lists;
    }

    [SerializeField]
    [Header("立ちの当たり判定")]
    GameObject[] standCollider = new GameObject[2];
    
    [SerializeField]
    [Header("しゃがみの当たり判定")]
    GameObject[] shitCollider = new GameObject[2];

    [SerializeField]
    [Header("変更する立ち絵")]
    public Sprite c_image;

    [SerializeField]
    [Header("デフォルトの立ち絵")]
    public Sprite d_image;

    [SerializeField]
    [Header("歩きの立ち絵")]
    public List<Sprite> w_Lists = new List<Sprite>();
    public List<Sprite> Getw_Lists()
    {
        return w_Lists;
    }

    [SerializeField]
    [Header("KOの立ち絵")]
    public List<Sprite> ko = new List<Sprite>();
    public List<Sprite> Getko()
    {
        return ko;
    }

    [SerializeField]
    [Header("しゃがみの立ち絵")]
    public Sprite s_image;
    [SerializeField]
    [Header("ガードの立ち絵")]
    public Sprite g_image;
    [SerializeField]
    [Header("しゃがみガードの立ち絵")]
    public Sprite sg_image;
    [SerializeField]
    [Header("ダメージ時の立ち絵")]
    public Sprite da_image;
    [SerializeField]
    [Header("必殺を受けた時の立ち絵")]
    public Sprite[] sp_image = new Sprite[5];
    [SerializeField]
    [Header("ジャンプの立ち絵")]
    public Sprite[] j_image = new Sprite[5];

    [MenuItem("Example/Create ExampleAsset Instance")]
    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<PlayerGet>();
        AssetDatabase.CreateAsset(exampleAsset, "Assets/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }
    
    // キャラID取得
    public int GetCharaID()
    {
        return m_charaID;
    }

    //[SerializeField]
    //int PlayerID = 1;

    //[SerializeField]
    //GameObject pget;    // Inspector上に1Pのキャラクターを入れる

    //PlayerSelect script;


    //Pselect = 0;


    //public void OnClick()
    //{
    //    // PlayerSelect.csのPlayer関数を呼び出して1Pをsetする。
    //    PlayerSelect.Instance.Player[PlayerID-1] = pget;
    //}


}
