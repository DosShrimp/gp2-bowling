using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public PinManager pm;
    public GameObject player;
    Throw th;

    List<GameObject> firstPins;
    List<Collapse> firstScripts;

    public List<GameObject> secondPins = new List<GameObject>();
    List<Collapse> secondScripts;

    public bool first_throw = true;
    public bool second_throw = false;

    int[] frameCount = {1, 1}; 
    int[] finalFrame = {10, 10};
    int[] finalFrame_throwCount = {0, 0};
    bool[] isEnd = {false, false};

    //倒れたピンの数
    public int collapsed = 0;

    bool player1Turn = true;
    bool player2turn = false;

    public SheetManager sm;

    public GameObject score;
    public GameObject player1FinalScore;
    public GameObject player2FinalScore;
    public GameObject player1Announcement;
    public GameObject player2Announcement;
    
    public GameObject playerTurntext;

    // Start is called before the first frame update
    void Start()
    {
        th = player.GetComponent<Throw>();
        firstPins = pm.firstPins;
        firstScripts = pm.firstScripts;
        secondScripts = pm.secondScripts;
    }

    // Update is called once per frame
    void Update()
    {   

        //全員のゲームの終了
        if(isEnd.All(i => i == true)) {
            score.SetActive(true);
            playerTurntext.SetActive(false);

            player1FinalScore.GetComponent<Text>().text = sm.finalScores[0].ToString();
            player2FinalScore.GetComponent<Text>().text = sm.finalScores[1].ToString();

            Debug.Log("ゲーム終了や！！");

            Debug.Log(sm.finalScores[0]);
            Debug.Log(sm.finalScores[1]);

            if(sm.finalScores[0] > sm.finalScores[1]) {

                player1Announcement.GetComponent<Text>().text = "WIN!!";
                player2Announcement.GetComponent<Text>().text = "LOSE..";
                
                player1Announcement.GetComponent<Text>().color = Color.red;
                player2Announcement.GetComponent<Text>().color = Color.blue;

            } else if(sm.finalScores[1] > sm.finalScores[0]) {

                player1Announcement.GetComponent<Text>().text = "LOSE..";
                player2Announcement.GetComponent<Text>().text = "WIN!!";

                player2Announcement.GetComponent<Text>().color = Color.red;
                player1Announcement.GetComponent<Text>().color = Color.blue;

            } else {

                player1Announcement.GetComponent<Text>().text = "DRAW";
                player2Announcement.GetComponent<Text>().text = "DRAW";

            }

            if(Input.GetKeyDown("space")) {
                
                SceneManager.LoadScene("Title");

            } else if(Input.GetKeyDown("r")) {

                SceneManager.LoadScene("Game");

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

        if(turn == 0) {
            
            playerTurntext.GetComponent<Text>().text = "プレイヤー1のターン";
            playerTurntext.GetComponent<Text>().color = Color.red;

            player.GetComponent<Renderer>().material.color = Color.red;

        } else {

            playerTurntext.GetComponent<Text>().text = "プレイヤー2のターン";
            playerTurntext.GetComponent<Text>().color = Color.blue;

            player.GetComponent<Renderer>().material.color = Color.blue;

        }



        //10フレームになるまで投げ続ける
        if(frameCount[turn] <= finalFrame[turn]) {
        
            //一回目の投げか？   
            if(first_throw) {   

                //ボールが奥に着いたか？&&すべてのピンが止まったか？
                if(th.arrived && firstPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                    //ストライクか？
                    if(firstScripts.All(i => i.judge == true)) {

                        Debug.Log("ストライク！！");

                        for(int j = 0; j < firstPins.Count; j++) {

                            Destroy(firstPins[j]);

                        }


                        firstPins.Clear();
                        firstScripts.Clear();
                        pm.generated = false;
                        th.Reset();

                        if(frameCount[turn] != finalFrame[turn]) {
                            
                            //スコアテキストの生成
                            var list = new List<int>(frameCount);
                            sm.GenerateText(turn, list[turn]-1, 1, 10);

                            //次のフレームへ
                            frameCount[turn] += 1;

                            ChangeTurn(turn);

                        //現在のフレームが10フレーム目か？10フレーム目で3回投げたか？
                        } else if(frameCount[turn] == finalFrame[turn]) {
                            
                            Debug.Log(finalFrame_throwCount[turn]);

                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, finalFrame_throwCount[turn], 10);

                            if(finalFrame_throwCount[turn] >= 2) {

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {
                                
                                finalFrame_throwCount[turn] += 1;

                                if(finalFrame_throwCount[turn] > 2) {

                                    finalFrame_throwCount[turn] = 2;

                                }

                            }
                        
                        }
                            

                    } else {
                        
                        //ピンの状態を確かめるぞ
                        for(int j = 0; j < firstPins.Count; j++) {
                            
                            //ピンはまだ立っているか？
                            if(!firstScripts[j].judge) {
                                
                                //二回目のピンのセット
                                secondPins.Add(Instantiate(firstPins[j], new Vector3(pm.pinLocations[j , 0], pm.pinLocations[j , 1], pm.pinLocations[j , 2]), Quaternion.identity));

                                Destroy(firstPins[j]);

                            } else {
                                
                                Destroy(firstPins[j]);

                            }

                        }

                        //現在のフレームは最終か？
                        if(frameCount[turn] == finalFrame[turn]) {

                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, finalFrame_throwCount[turn], 10 - secondPins.Count());

                            if(finalFrame_throwCount[turn] >= 2) {
                                                    
                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {

                                finalFrame_throwCount[turn] += 1;

                                if(finalFrame_throwCount[turn] > 2) {

                                    finalFrame_throwCount[turn] = 2;

                                }

                            }

                        } else {
                            
                            //スコアテキストの生成
                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, 1, 10 - secondPins.Count());

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
                    
                //ボールが奥に着いたか？&&すべてのピンが止まったか？
                if(th.arrived && secondPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                    //スペアか？
                    if(secondScripts.All(i => i.judge == true)) {
                
                        Debug.Log("スペアや！");

                        for(int j = 0; j < secondPins.Count(); j++) {

                            Destroy(secondPins[j]);
                        }


                        first_throw = true;
                        pm.generated = false;
                        th.Reset();
                        second_throw = false;

                        if(frameCount[turn] != finalFrame[turn]) {

                            //スコアテキストの生成
                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, 2, 300);

                            frameCount[turn] += 1;
                            ChangeTurn(turn);

                        } else if(frameCount[turn] == finalFrame[turn]) {

                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, finalFrame_throwCount[turn], 300);

                            if(finalFrame_throwCount[turn] >= 2) {

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {

                                finalFrame_throwCount[turn] += 2;

                                if(finalFrame_throwCount[turn] > 2) {

                                    finalFrame_throwCount[turn] = 2;

                                }
                        
                            }
                        
                        }
                        
                        secondPins.Clear();
                        secondScripts.Clear();

                    //スペアじゃないとき
                    } else {
                        
                        for(int j = 0; j < secondPins.Count; j++) {

                            if(secondScripts[j].judge) {
                                collapsed += 1;
                            }

                            Destroy(secondPins[j]);
                        }

                        first_throw = true;
                        pm.generated = false;
                        th.Reset();
                        second_throw = false;

                        if(frameCount[turn] != finalFrame[turn]) {

                            //スコアテキストの生成
                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, 2, collapsed);

                            frameCount[turn] += 1;
                            ChangeTurn(turn);

                        } else if(frameCount[turn] == finalFrame[turn]) {
                                
                            finalFrame_throwCount[turn] += 2;
                            
                            if(finalFrame_throwCount[turn] > 2) {

                                finalFrame_throwCount[turn] = 2;

                            }

                            var list2 = new List<int>(frameCount);
                            sm.GenerateText(turn, list2[turn]-1, finalFrame_throwCount[turn], collapsed);
                            
                            if(finalFrame_throwCount[turn] >= 2) {

                                frameCount[turn] += 1;
                                ChangeTurn(turn);

                            } else {

                                finalFrame_throwCount[turn] += 1;
                        
                            }
                        
                        }

                        secondPins.Clear();
                        secondScripts.Clear();
                        collapsed = 0;

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

    public int GetSecondPinsCount() {
    
        return secondPins.Count;
    
    }

    public int GetCollapsed() {

        return collapsed;
    
    }
}
