using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharas : MonoBehaviour {
    

    [SerializeField] SpriteRenderer _1pSpr;
    [SerializeField] SpriteRenderer _2pSpr;

    [SerializeField] GameObject text;
    [SerializeField] bool select1p = false;
    [SerializeField] bool select2p = false;
    string _1pchara;
    string _2pchara;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (select1p == true && select2p == true)
        {
            if (Input.GetKeyDown("joystick 1 button 3"))
            {
                SceneManagers.Instance.ChangeSceneState();
            }
            else if (Input.GetKeyDown("joystick 2 button 3"))
            {
                SceneManagers.Instance.ChangeSceneState();
            }
        }
    }
    public void ChoisChara(Collider2D collision, int num)
    {
        switch (num)
        {
            case 1:
                if (collision.gameObject.tag == "2P") return;
                var _spriteRenderer1p = collision.gameObject.GetComponent<SpriteRenderer>();
                _1pSpr.sprite = _spriteRenderer1p.sprite;
                _1pchara = _1pSpr.sprite.name;
                Debug.Log(_1pchara);
                select1p = true;
                EndSelectChara();
                break;
            case 2:
                if (collision.gameObject.tag == "1P") return;
                var _spriteRenderer2p = collision.gameObject.GetComponent<SpriteRenderer>();
                _2pSpr.sprite = _spriteRenderer2p.sprite;
                _2pchara = _2pSpr.sprite.name;
                Debug.Log(_2pchara);
                select2p = true;
                EndSelectChara();
                break;
        }
    }
    public void ReSelect(int num)
    {

        if (num == 1)
        {
            if (_1pSpr.sprite == null) return;
            _1pSpr.sprite = null;
            select1p = false;
            EndSelectChara();
            Debug.Log("P1 1 button");
        }
        else if (num == 2)
        {
            if (_2pSpr.sprite == null) return;
            _2pSpr.sprite = null;
            select2p = false;
            EndSelectChara();
            Debug.Log("P2 1 button");
        }
    }

    private void EndSelectChara()
    {
        if (select1p == true && select2p == true)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
