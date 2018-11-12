using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : SingletonMonoBehavior<StatusManager> {

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


    //必殺ゲージ
    int[] deathblowGuage = new int[2]{0,0};
    public int[] DeathblowGuage{
        get{return deathblowGuage;}
    }


    private void Update(){
        DeleteCommand();

        /*
        if (Input.GetKeyDown(KeyCode.A))
            SetCommandOnePlayer(4);
        if (Input.GetKeyDown(KeyCode.S))
            SetCommandOnePlayer(6);
        if (Input.GetKeyDown(KeyCode.F))
            SetCommandTwoPlayer(6);
        if (Input.GetKeyDown(KeyCode.D))
            SetCommandTwoPlayer(4);
        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log(CheckCommand(1));
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log(CheckCommand(3));
        }
        */
    }
    
    //1Pのコマンド履歴に追記
    public void SetCommandOnePlayer(int command){
        //コマンドが押しっぱなしならそのまま返す
        if (onePlayerKey == command) {
            //Debug.Log("同じキーやで");
            return;
        }
        if (onePlayerCommandList.Count <= 1) {
            timerCountOne = 0;
        }
        onePlayerCommandList.Add(command);
        //Debug.Log("1Pコマンド：" + command);
        onePlayerKey = command;
    }
    
    //2Pのコマンド履歴に追記
    public void SetCommandTwoPlayer(int command){
        //コマンドが押しっぱなしならそのまま返す
        if (twoPlayerKey == command) {
            //Debug.Log("同じキーやで");
            return;
        }

        if (twoPlayerCommandList.Count <= 1) {
            timerCountTwo = 0;
        }
        twoPlayerCommandList.Add(command);
        //Debug.Log("2Pコマンド：" + command);
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
                //Debug.Log("1PCommandDel");
            }
        }
        if (timerCountTwo >= timer) {
            timerCountTwo =0;
            if (twoPlayerCommandList.Count > 2) {
                twoPlayerCommandList.RemoveAt(0);
                //Debug.Log("2PCommandDel");
            }
        }
    }

    //コマンドのチェック
    public char CheckCommand(int player) {
        List<int> commandlist = onePlayerCommandList;
        if(player == 1) {
            commandlist = onePlayerCommandList;
        }
        else if(player == 2) {
            commandlist = twoPlayerCommandList;
        }
        else {
            Debug.LogError("コマンドチェックの参照は必ず１か２を選択して下さい。");
            return '5';
        }
        
        char command = '5';

        //コマンドの実装
        int lengh = commandlist.Count;
        //Debug.Log(lengh);
        if (commandlist[lengh-1] == 8) {
            command = 'j';
        }
        if (commandlist[lengh-1] == 2) {
            command = 'd';
        }
        if (commandlist[lengh-1] == 6) {
            command = 'r';
            if (lengh >= 3) { return command; }
            if (commandlist[lengh - 2] == 5 && commandlist[lengh - 3] == 6) {
                command = 'S';
            }
        }
        if (commandlist[lengh-1] == 3) {
            command = 'e';
        }
        if (commandlist[lengh-1] == 9) {
            command = 'c';
        }
        if(commandlist[lengh-1] == 4) {
            command = 'l';
            if (lengh >= 3) { return command; }
            if (commandlist[lengh - 2] == 5 && commandlist[lengh - 3] == 4) {
                command = 's';
            }
        }
        if(commandlist[lengh-1] == 1) {
            command = 'q';
        }
        if(commandlist[lengh-1] == 7) {
            command = 'z';
        }
        return command;
    }

    //ゲージの上昇
    public void GuageUp(int player ,int pow) {
        if(player > 2) {
            Debug.LogError("ゲージ上昇は必ず１か２を選択して下さい。");
            return;
        }
        deathblowGuage[player - 1] += pow;
        if (deathblowGuage[player - 1] >= 100) { deathblowGuage[player - 1] = 100; }
        //Debug.Log("ゲージ量_1P:" + deathblowGuage[0] + "2P:" + deathblowGuage[1]);
    }

    public bool GuageUse(int player) {
        if(player > 2) {
            Debug.LogError("ゲージ上昇は必ず１か２を選択して下さい。");
            return false;
        }
        if(deathblowGuage[player-1] > 100) { return false; }
        deathblowGuage[player - 1] = 0;
        return true;
    }
}
