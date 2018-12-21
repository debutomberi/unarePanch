using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSporn : MonoBehaviour {


    [SerializeField]
    int playerID;

    PlayerSelect script;
    GameObject _player;     // playerの入れ物
    GameObject status;
    float speed;
    float jump;
    List<GameObject> ACOP = new List<GameObject>();
    PlayerManager pScript;
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        // PlayerGet.cs内でsetしたプレイヤーをgetする。
        _player = PlayerSelect.Instance.Player[playerID - 1];
        // _playerに何も入ってなかったらreturn
        if (_player == null) return;
        Vector3 pos = _player.transform.position;
        _player.transform.position = new Vector3(-5, 0, 0);
        Debug.Log(_player.transform.position);

        speed = pScript.Speed;
        jump = pScript.Jump;
        ACOP = pScript.attackColliderOnePlayer;
        Debug.Log(speed + "スピード");
        Debug.Log(jump + "ジャンプ");
        Debug.Log(ACOP + "1P");

    }

    void Awake()
    {
        /*
        // PlayerGet.cs内でsetしたプレイヤーをgetする。
        _player = PlayerSelect.Instance.Player[playerID - 1];
        _player.transform.position = Vector3.zero;
        */
        status = GameObject.Find("PlayerManager");
        pScript = status.GetComponent<PlayerManager>();
        
        //攻撃・スピード・ジャンプの情報を取得
    }

    public void Pset()
    {
        //// PlayerGet.cs内でsetしたプレイヤーをgetする。
        //_player = PlayerSelect.Instance.Player[playerID - 1];
        //// _playerに何も入ってなかったらreturn
        //if (_player == null) return;
        //_player.transform.position = new Vector3(10, 10, 0);
        //Debug.Log(_player.transform.position);
    }
}
