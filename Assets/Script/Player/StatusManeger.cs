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

    //コマンド履歴を消すまでの時間
    int timerCountOne;
    int timerCountTwo;
    const int timer = 20;
    

    private void Update(){
        DeleteCommand();
    }
    
    //1Pのコマンド履歴に追記
    public void SetCommandOnePlayer(int command){

        if (onePlayerCommandList.Count <= 1) {
            timerCountOne = 0;
        }
        onePlayerCommandList.Add(command);
        
    }
    
    //2Pのコマンド履歴に追記
    public void SetCommandTwoPlayer(int command){

        if (twoPlayerCommandList.Count <= 1) {
            timerCountTwo = 0;
        }
        twoPlayerCommandList.Add(command);
        
    }
    
    //コマンド履歴の削除
    void DeleteCommand() {
        timerCountOne++;
        timerCountTwo++;
        if(timerCountOne >= timer) {
            timerCountOne = 0;
            if(onePlayerCommandList.Count > 1) {
                onePlayerCommandList.RemoveAt(0);
                Debug.Log("1PCommandDel");
            }
        }
        if (timerCountTwo >= timer) {
            timerCountTwo =0;
            if (twoPlayerCommandList.Count > 1) {
                twoPlayerCommandList.RemoveAt(0);
                Debug.Log("2PCommandDel");
            }
        }
    }

}
