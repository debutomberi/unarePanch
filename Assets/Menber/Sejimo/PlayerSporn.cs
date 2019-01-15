using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSporn : MonoBehaviour {


    [SerializeField]
    int playerID;

    PlayerSelect script;
    GameObject _player;     // playerの入れ物

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
    }

    void PlayerAwake()
    {
        // PlayerGet.cs内でsetしたプレイヤーをgetする。
        _player = PlayerSelect.Instance.Player[playerID - 1];
        _player.transform.position = Vector3.zero;
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
