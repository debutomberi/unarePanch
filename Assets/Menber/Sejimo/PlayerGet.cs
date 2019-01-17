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
                                // 攻撃方法

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
