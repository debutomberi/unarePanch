using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerGet : ScriptableObject {

    [SerializeField]
    private int m_charaID;      // ID
    [SerializeField]
    private int Speed;        // スピード
    [SerializeField]
    private int Jump;         // ジャンプ力
                              // 攻撃表
    [SerializeField]
    public int a_col;          //攻撃のコライダー
    [SerializeField]
    [Header("立ちの当たり判定")]
    public bool st_col;
    [SerializeField]
    [Header("座りの当たり判定")]
    public bool sit_col;
                             //変更する立ち絵
    [SerializeField]
    [Header("デフォルトの立ち絵")]
    public Sprite d_image;
    [SerializeField]
    [Header("歩きの立ち絵")]
    public Sprite[] w_image = new Sprite[5];
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
