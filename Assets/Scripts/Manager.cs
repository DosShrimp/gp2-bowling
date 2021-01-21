using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public PinManager pm;
    public GameObject gcText;

    public GameObject player;
    Throw th;

    public GameObject goText;

    List<GameObject> firstPins;
    List<Collapse> firstScripts;

    public List<GameObject> secondPins = new List<GameObject>();
    List<Collapse> secondScripts;

    public bool first_throw = true;
    public bool second_throw = false;

    int[] frameCount = {1, 1}; 
    int[] finalFrame = {3, 3};
    int[] finalFrame_throwCount = {0, 0};
    bool[] isEnd = {false, false};

    public int[][] score;

    //倒れたピンの数
    int collapsed = 0;

    bool player1Turn = true;
    bool player2turn = false;

    public SheetManager sm;

    // Start is called before the first frame update
    void Start()
    {
        th = player.GetComponent<Throw>();
        firstPins = pm.firstPins;
        firstScripts = pm.firstScripts;
        secondScripts = pm.secondScripts;

        score = new int[2][];
        score[0] = new int[finalFrame[0]];
        score[1] = new int[finalFrame[1]];
    }

    // Update is called once per frame
    void Update()
    {   

        //全員のゲームの終了
        if(isEnd.All(i => i == true)) {
            Debug.Log("ゲーム終了や！！");

            Debug.Log("プレイヤー0のスコア");
            for(int i = 0; i < score[0].Count(); i++) {
                Debug.Log(score[0][i]);
            }

            Debug.Log("プレイヤー1のスコア");
            for(int i = 0; i < score[1].Count(); i++) {
                Debug.Log(score[1][i]);
            }
        
        //プレイヤー1の番か？
        } else if(player1Turn) {
            Debug.Log(isEnd[0]);
            Game(0);

        //プレイヤー2の番か？
        } else if(player2turn) {
            Debug.Log(isEnd[1]);
            Game(1);

        } 
    }

    void Game(int turn) {

        Debug.Log(turn + "の番です");

        // Debug.Log(frameCount + "フレーム目やで");

        //10フレームになるまで投げ続ける
        if(frameCount[turn] <= finalFrame[turn]) {
        
            //一回目の投げか？   
            if(first_throw) {   

                // Debug.Log("今は１回目の投げや");

                //ボールが奥に着いたか？&&すべてのピンが止まったか？
                if(th.arrived && firstPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                    //ストライクか？
                    if(firstScripts.All(i => i.judge == true)) {

                        Debug.Log("ストライク！！");

                        for(int j = 0; j < firstPins.Count; j++) {

                            Destroy(firstPins[j]);

                        }

                        var list = new List<int>(frameCount);
                        score[turn][list[turn]-1] = 10;

                        firstPins.Clear();
                        firstScripts.Clear();
                        pm.generated = false;
                        th.Reset();

                        if(frameCount[turn] != finalFrame[turn]) {

                            //次のフレームへ
                            frameCount[turn] += 1;

                            // var list2 = new List<int>(frameCount);
                            // sm.GenerateText(player1Turn, list2[turn]-1);

                            ChangeTurn(turn);

                        //現在のフレームが10フレーム目か？10フレーム目で3回投げたか？
                        } else if(frameCount[turn] == finalFrame[turn]) {
                            

                            if(finalFrame_throwCount[turn] >= 2) {

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {

                                finalFrame_throwCount[turn] += 1;
                            
                            }
                        
                        }
                            

                    } else {
                        
                        //ピンの状態を確かめるぞ
                        for(int j = 0; j < firstPins.Count; j++) {
                            
                            //ピンはまだ立っているか？
                            if(!firstScripts[j].judge) {
                                
                                //二回目のピンのセット
                                secondPins.Add(Instantiate(firstPins[j], firstPins[j].transform.position, Quaternion.identity));

                                Destroy(firstPins[j]);

                            } else {
                                
                                Destroy(firstPins[j]);

                            }

                        }


                        //現在のフレームは最終か？
                        if(frameCount[turn] == finalFrame[turn]) {

                            if(finalFrame_throwCount[turn] >= 2) {
                        
                                score[turn][frameCount[turn]] = 10 - secondPins.Count();

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {

                                finalFrame_throwCount[turn] += 1;
                            
                            }

                        }
                    
                        //最後にいろいろリセット
                        firstPins.Clear();
                        firstScripts.Clear();
                        second_throw = true;
                        pm.generated = false;
                        th.Reset();
                        first_throw = false;

                    }

                } 


            //２回目の投げか？       
            } else if(second_throw) {
                    
                // Debug.Log("今は２回目の投げや");

                    //ボールが奥に着いたか？&&すべてのピンが止まったか？
                    if(th.arrived && secondPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                        //スペアか？
                        if(secondScripts.All(i => i.judge == true)) {
                    
                            Debug.Log("スペアや！");


                            for(int j = 0; j < secondPins.Count(); j++) {
                                Destroy(secondPins[j]);
                            }

                            score[turn][frameCount[turn]] = 10;

                            secondPins.Clear();
                            secondScripts.Clear();
                            first_throw = true;
                            pm.generated = false;
                            th.Reset();
                            second_throw = false;


                            if(frameCount[turn] != finalFrame[turn]) {

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else if(frameCount[turn] == finalFrame[turn]) {

                                if(finalFrame_throwCount[turn] >= 2) {

                                    frameCount[turn] += 1;
                                    ChangeTurn(turn);

                                } else {

                                    finalFrame_throwCount[turn] += 2;
                            
                                }
                            
                            }

                        //スペアじゃないとき
                        } else {
                            
                            for(int j = 0; j < secondPins.Count; j++) {

                                if(secondScripts[j].judge) {
                                    collapsed += 1;
                                }

                                Destroy(secondPins[j]);
                            }

                            score[turn][frameCount[turn]] = collapsed;

                            collapsed = 0;
                            secondPins.Clear();
                            secondScripts.Clear();
                            first_throw = true;
                            pm.generated = false;
                            th.Reset();
                            second_throw = false;

                            if(frameCount[turn] != finalFrame[turn]) {

                                frameCount[turn] += 1;

                            } else if(frameCount[turn] == finalFrame[turn]) {
                                
                                finalFrame_throwCount[turn] += 2;

                                if(finalFrame_throwCount[turn] >= 2) {

                                    frameCount[turn] += 1;
                                    ChangeTurn(turn);

                                } else {

                                    finalFrame_throwCount[turn] += 1;
                            
                                }
                            
                            }

                        }


                    }

            }
            
            Debug.Log(frameCount[turn] + "フレーム目");

        } else {

            isEnd[turn] = true;
            ChangeTurn(turn);
            Debug.Log("ゲーム終了");

        }
        
    }

    void ChangeTurn(int _turn) {

        if(_turn == 0) {

            player1Turn = false;
            player2turn = true;

        } else {

            player1Turn = true;
            player2turn = true;
                                
        }
    }
}
