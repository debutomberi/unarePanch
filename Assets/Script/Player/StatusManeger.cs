using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManeger : SingletonMonoBehavior<StatusManeger> {

    //１Pのコマンド履歴
    private List<int> onePlayerCommandList =new List<int>();
    public List<int> OnePlayerCommandList{
        get{ return onePlayerCommandList;}
        
    }

    //2Pのコマンド履歴
    private List<int> twoPlayerCommandList = new List<int>();
    public List<int> TwoPlayerCommandList{
        get{return twoPlayerCommandList;}

    }

    //各最終コマンドのチェック
    int onePlayerKey = 5;
    int twoPlayerKey = 5;

    //コマンド履歴を消すまでの時間
    int timerCountOne;
    int timerCountTwo;
    const int timer = 20;
    

    private void Update(){
        DeleteCommand();


        if (Input.GetKeyDown(KeyCode.A))
            SetCommandOnePlayer(4);
        if (Input.GetKeyDown(KeyCode.S))
            SetCommandOnePlayer(6);
        if (Input.GetKeyDown(KeyCode.F))
            SetCommandTwoPlayer(6);
        if (Input.GetKeyDown(KeyCode.D))
            SetCommandTwoPlayer(4);
        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log(CheckCommandOnePlayer());
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(CheckCommandTwoPlayer());
        }
        
    }
    
    //1Pのコマンド履歴に追記
    public void SetCommandOnePlayer(int command){
        //コマンドが押しっぱなしならそのまま返す
        if (onePlayerKey == command) {
            Debug.Log("同じキーやで");
            return;
        }
        if (onePlayerCommandList.Count <= 1) {
            timerCountOne = 0;
        }
        onePlayerCommandList.Add(command);
        Debug.Log("1Pコマンド：" + command);
        onePlayerKey = command;
    }
    
    //2Pのコマンド履歴に追記
    public void SetCommandTwoPlayer(int command){
        //コマンドが押しっぱなしならそのまま返す
        if (twoPlayerKey == command) {
            Debug.Log("同じキーやで");
            return;
        }

        if (twoPlayerCommandList.Count <= 1) {
            timerCountTwo = 0;
        }
        twoPlayerCommandList.Add(command);
        Debug.Log("2Pコマンド：" + command);
        twoPlayerKey = command;
    }
    
    //コマンド履歴の削除
    void DeleteCommand() {
        timerCountOne++;
        timerCountTwo++;
        if(timerCountOne >= timer) {
            timerCountOne = 0;
            if(onePlayerCommandList.Count > 2) {
                onePlayerCommandList.RemoveAt(0);
                Debug.Log("1PCommandDel");
            }
        }
        if (timerCountTwo >= timer) {
            timerCountTwo =0;
            if (twoPlayerCommandList.Count > 2) {
                twoPlayerCommandList.RemoveAt(0);
                Debug.Log("2PCommandDel");
            }
        }
    }

    
    public char CheckCommandOnePlayer() {
       
        
        char command = '5';

        //コマンドの実装
        int lengh = onePlayerCommandList.Count;
        //Debug.Log(lengh);
        if (onePlayerCommandList[lengh-1] == 6) {


            command = 'a';
        }
        if(onePlayerCommandList[lengh-1] == 4) {


            command = 'r';
        }

        return command;
    }

    public char CheckCommandTwoPlayer() {
        
        char command = '5';

        //コマンドの実装
        int lengh = twoPlayerCommandList.Count;
        //Debug.Log(lengh);
        if(twoPlayerCommandList[lengh-1] == 6) {


            command = 'a';
        }
        if(twoPlayerCommandList[lengh-1] == 4) {


            command = 'r';
        }

        return command;
    }
    

}
