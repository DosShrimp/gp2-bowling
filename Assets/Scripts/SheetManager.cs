using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetManager : MonoBehaviour
{
    public Manager m;
    public GameObject text;
    public GameObject tp;

    public List<List<int>> player1Score = new List<List<int>>();
    public List<List<int>> player2Score = new List<List<int>>();
    public List<GameObject> texts1 = new List<GameObject>();
    public List<GameObject> texts2 = new List<GameObject>();

    List<int> sFrame10Point1 = new List<int>();
    List<int> sFrame10Point2 = new List<int>();

    int frame10Point1 = 0;
    int frame10Point2 = 0;

    bool scoreComfirmed = false;

    public void GenerateText(int turn, int frame, int throw_count, int score = 999) {

        //上段のスコア表示
        float y = 30.0f;
        float x = -130.0f;

        GameObject o = Instantiate(text);

        RectTransform rt = o.GetComponent(typeof (RectTransform)) as RectTransform;

        Text tx = o.GetComponent<Text>(); 

        //プレイヤー1
        if(turn == 0) {

            y = 30.0f;
                    
        //プレイヤー2
        } else {

            y = -1.0f;

        }
        
        //9フレーム目まで 0~8
        if(frame <= 8) { 

            if(throw_count == 2) {

                x = -110;
                
            } else {

                x = -130;

            }

            rt.transform.SetParent(tp.transform);
            rt.transform.localPosition = new Vector3(x + (47.5f * frame), y, 0);
            
            //一回目の投げ
            if(throw_count == 1) {

                //ストライクか？
                if(score == 10) {

                    scoreComfirmed = true;

                    tx.text = "S";

                    //プレイヤー1
                    if(turn == 0) {

                        List<int> player1Point = new List<int>();
                        player1Point.Add(0);
                        player1Point.Add(10);
                    
                        player1Score.Add(player1Point);

                        //下段表示
                        if(player1Score.Count > 0) {

                            y = 16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);

                            texts1.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                    
                        }


                    //プレイヤー2
                    } else {

                        List<int> player2Point = new List<int>();
                        player2Point.Add(0);
                        player2Point.Add(10);
                    
                        player2Score.Add(player2Point);

                        //下段表示
                        if(player2Score.Count > 0) {

                            y = -16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);

                            texts2.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                        
                        }

                    }

                } else {

                    tx.text = score.ToString();
                
                }

            //２回目の投げ
            } else {

                scoreComfirmed = true;

                //スペア
                if(score >= 300) {

                    tx.text = "◢"; 

                    //プレイヤー1
                    if(turn == 0) {

                        List<int> player1Point = new List<int>();
                        player1Point.Add(1);
                        player1Point.Add(10);
                    
                        player1Score.Add(player1Point);

                        //下段表示
                        if(player1Score.Count > 0) {

                            y = 16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);
                            
                            texts1.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                    
                        }

                    //プレイヤー2
                    } else {

                        List<int> player2Point = new List<int>();
                        player2Point.Add(1);
                        player2Point.Add(10);
                    
                        player2Score.Add(player2Point);

                        //下段表示
                        if(player2Score.Count > 0) {

                            y = -16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);

                            texts2.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                        
                        }

                    }

                //それ以外
                } else {

                    tx.text = score.ToString();

                    //プレイヤー1
                    if(turn == 0) {

                        int secondPinsCount = m.GetSecondPinsCount();

                        int collapsed = m.GetCollapsed();
                        List<int> player1Point = new List<int>();

                        player1Point.Add(2);

                        //一回目のスコアが0じゃなかったら
                        if(10 - secondPinsCount != 0) {

                            player1Point.Add(10 - secondPinsCount + collapsed);

                        } else {

                            player1Point.Add(collapsed);

                        }
                        
                        player1Score.Add(player1Point);

                        //下段表示
                        if(player1Score.Count > 0) {

                            y = 16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);

                            texts1.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                    
                        }

                    //プレイヤー2
                    } else {
                        
                        int secondPinsCount = m.GetSecondPinsCount();
                        int collapsed = m.GetCollapsed();
                        List<int> player2Point = new List<int>();

                        player2Point.Add(2);

                        if(10 - secondPinsCount != 0) {

                            player2Point.Add(10 - secondPinsCount + collapsed);

                        } else {

                            player2Point.Add(collapsed);

                        }
                        
                        player2Score.Add(player2Point);

                        //下段表示
                        if(player2Score.Count > 0) {

                            y = -16.5f;
                            x = -120.0f + (47.5f * frame);

                            GameObject o2 = Instantiate(text);

                            texts2.Add(o2);

                            RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                            Text tx2 = o2.GetComponent<Text>(); 
                    
                            rt2.transform.SetParent(tp.transform);
                            rt2.transform.localPosition = new Vector3(x, y, 0);

                            tx2.text = "";
                            
                        
                        }

                    }

                }
           }

        //10フレーム目
        } else {

            if(throw_count == 0) {

                x = 297.0f;

            } else if(throw_count == 1) {

                x = 320.0f;

            } else {

                x = 340.0f;

            }

            rt.transform.SetParent(tp.transform);
            rt.transform.localPosition = new Vector3(x, y, 0);

            if(score == 10) {

                tx.text = "S";

                //プレイヤー1
                if(turn == 0) {

                    frame10Point1 += 10;
                    sFrame10Point1.Add(10);

                //プレイヤー2
                } else {

                    frame10Point2 += 10;
                    sFrame10Point2.Add(10);
                }

            } else if(score >= 300) {

                tx.text = "◢";

                 //プレイヤー1
                if(turn == 0) {

                    frame10Point1 += 10;
                    sFrame10Point1.Add(10);

                //プレイヤー2
                } else {

                    frame10Point2 += 10;
                    sFrame10Point2.Add(10);

                }

            } else {

                tx.text = score.ToString();

                 //プレイヤー1
                if(turn == 0) {

                    frame10Point1 += score;
                    sFrame10Point1.Add(score);

                //プレイヤー2
                } else {

                    frame10Point2 += score;
                    sFrame10Point2.Add(score);

                }

                if(throw_count == 2) {

                    if(sFrame10Point1.Count == 2) {

                        if(throw_count == 2) {
                        
                            x = 320.0f;

                        }

                    } else if(sFrame10Point1.Count == 3) {

                        Debug.Log("auio");
                        x = 340.0f;

                    }

                    if(sFrame10Point2.Count == 2) {

                        if(throw_count == 2) {
                        
                            x = 320.0f;

                        }

                    } else if(sFrame10Point2.Count == 3) {

                        Debug.Log("auio");
                        x = 340.0f;

                    }
                    
                }

                rt.transform.SetParent(tp.transform);
                rt.transform.localPosition = new Vector3(x, y, 0);

            }

            //下段のスコア表示
            if(throw_count == 2) {

                //プレイヤー1
                if(turn == 0) {

                    y = 16.5f;
                    x = 320;
                    
                    List<int> player1Point = new List<int>();
                    player1Point.Add(2);
                    player1Point.Add(frame10Point1);

                    player1Score.Add(player1Point);

                    GameObject o2 = Instantiate(text);

                    texts2.Add(o2);

                    RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                    Text tx2 = o2.GetComponent<Text>(); 
                    
                    rt2.transform.SetParent(tp.transform);
                    rt2.transform.localPosition = new Vector3(x, y, 0);

                    //8フレーム目がストライクなら
                    if(player1Score[frame-2][0] == 0) {

                        if(player1Score[frame-1][0] == 0) {

                            player1Score[frame-2][1] += player1Score[frame-1][1];
                            player1Score[frame-2][1] += sFrame10Point1[0];

                        } else {

                            player1Score[frame-2][1] += player1Score[frame-1][1];

                        }
                        
                        int totalpoint = 0; 
                        for(int i = 0; i < player1Score.Count-2; i++) {

                            totalpoint += player1Score[i][1];

                        }

                        texts1[frame-2].GetComponent<Text>().text = totalpoint.ToString();

                    } 

                    //9フレーム目がストライクなら
                    if(player1Score[frame-1][0] == 0) {

                        if(sFrame10Point1[0] != 10 && sFrame10Point1[1] == 10) {

                            player1Score[frame-1][1] += sFrame10Point1[1];

                        } else {

                            player1Score[frame-1][1] += sFrame10Point1[0];
                            player1Score[frame-1][1] += sFrame10Point1[1];

                        }

                        int totalpoint = 0; 
                        for(int i = 0; i < player1Score.Count-1; i++) {

                            totalpoint += player1Score[i][1];

                        }

                        texts1[frame-1].GetComponent<Text>().text = totalpoint.ToString();

                    //9フレーム目がスペアなら
                    } else if(player1Score[frame-1][0] == 1) {

                        player1Score[frame-1][1] += sFrame10Point1[0];

                        int totalpoint = 0; 
                        for(int i = 0; i < player1Score.Count-1; i++) {

                            totalpoint += player1Score[i][1];

                        }

                        texts1[frame-1].GetComponent<Text>().text = totalpoint.ToString();

                    //9フレーム目がスペアでもストライクでもないなら
                    } else if(player1Score[frame-1][0] == 2) {

                        int totalpoint = 0; 
                        for(int i = 0; i < player1Score.Count-1; i++) {

                            totalpoint += player1Score[i][1];

                        }

                        texts1[frame-1].GetComponent<Text>().text = totalpoint.ToString();

                    }

                    //スコアの合計の表示
                    x = 387.5f;
                    y = 22;

                    GameObject o3 = Instantiate(text);

                    RectTransform rt3 = o3.GetComponent(typeof (RectTransform)) as RectTransform;

                    Text tx3 = o3.GetComponent<Text>(); 
                    
                    rt3.transform.SetParent(tp.transform);
                    rt3.transform.localPosition = new Vector3(x, y, 0);

                    int finalScore = 0;
                    for(int i = 0; i < player1Score.Count; i++) {

                        finalScore += player1Score[i][1];

                    } 

                    if(sFrame10Point1.Count > 2) {

                        if(sFrame10Point1[0] == 10 && sFrame10Point1[1] == 10 && sFrame10Point1[2] == 10) {

                            Debug.Log("hoge"); 

                        } else if(sFrame10Point1[0] == 10 && sFrame10Point1[2] == 10) {
                            
                            finalScore -= sFrame10Point1[1];

                        } else if(sFrame10Point1[1] == 10 && sFrame10Point1[2] == 10) {

                            finalScore -= sFrame10Point1[0];

                        }
                    
                    }


                    tx2.text = finalScore.ToString();
                    tx3.text = finalScore.ToString();

                //プレイヤー2
                } else {

                    y = -16.5f;
                    x = 320;
                    
                    List<int> player2Point = new List<int>();
                    player2Point.Add(2);
                    player2Point.Add(frame10Point2);

                    player2Score.Add(player2Point);

                    GameObject o2 = Instantiate(text);

                    texts2.Add(o2);

                    RectTransform rt2 = o2.GetComponent(typeof (RectTransform)) as RectTransform;

                    Text tx2 = o2.GetComponent<Text>(); 
                    
                    rt2.transform.SetParent(tp.transform);
                    rt2.transform.localPosition = new Vector3(x, y, 0);

                    tx2.text = player2Score[frame][1].ToString();

                    //8フレーム目がストライクなら
                    if(player2Score[frame-2][0] == 0) {
                        
                        if(player2Score[frame-1][0] == 0) {

                            player2Score[frame-2][1] += player2Score[frame-1][1];
                            player2Score[frame-2][1] += sFrame10Point2[0];

                        } else {
                            
                            player2Score[frame-2][1] += player2Score[frame-1][1];

                        }

                        int totalpoint = 0; 
                        for(int i = 0; i < player2Score.Count-2; i++) {

                            totalpoint += player2Score[i][1];

                        }

                        texts2[frame-2].GetComponent<Text>().text = totalpoint.ToString();

                    } 

                    //9フレーム目がストライクなら
                    if(player2Score[frame-1][0] == 0) {

                        if(sFrame10Point2[0] != 10 && sFrame10Point2[1] == 10) {

                            player2Score[frame-1][1] += sFrame10Point2[1];

                        } else {

                            player2Score[frame-1][1] += sFrame10Point2[0];
                            player2Score[frame-1][1] += sFrame10Point2[1];

                        }

                        int totalpoint = 0; 
                        for(int i = 0; i < player2Score.Count-1; i++) {

                            totalpoint += player2Score[i][1];

                        }

                        texts2[frame-1].GetComponent<Text>().text = totalpoint.ToString();

                    //9フレーム目がスペアなら
                    } else if(player2Score[frame-1][0] == 1) {

                        player2Score[frame-1][1] += sFrame10Point2[0];

                        int totalpoint = 0; 
                        for(int i = 0; i < player2Score.Count-1; i++) {

                            totalpoint += player2Score[i][1];

                        }

                        texts2[frame-1].GetComponent<Text>().text = totalpoint.ToString();
                    
                    //9フレーム目がスペアでもストライクでもないなら
                    } else if(player2Score[frame-1][0] == 2) {

                        int totalpoint = 0; 
                        for(int i = 0; i < player2Score.Count-1; i++) {

                            totalpoint += player2Score[i][1];

                        }

                        texts2[frame-1].GetComponent<Text>().text = totalpoint.ToString();

                    }


                    //スコアの合計の表示
                    x = 387.5f;
                    y = -10;
                    
                    GameObject o3 = Instantiate(text);

                    RectTransform rt3 = o3.GetComponent(typeof (RectTransform)) as RectTransform;

                    Text tx3 = o3.GetComponent<Text>(); 
                    
                    rt3.transform.SetParent(tp.transform);
                    rt3.transform.localPosition = new Vector3(x, y, 0);

                    int finalScore = 0;
                    for(int i = 0; i < player2Score.Count; i++) {

                        finalScore += player2Score[i][1];

                    } 

                    if(sFrame10Point2.Count > 2) {

                        if(sFrame10Point2[0] == 10 && sFrame10Point2[1] == 10 && sFrame10Point2[2] == 10) {

                            Debug.Log("hoge"); 

                        } else if(sFrame10Point2[0] == 10 && sFrame10Point2[2] == 10) {
                            
                            finalScore -= sFrame10Point2[1];

                        } else if(sFrame10Point2[1] == 10 && sFrame10Point2[2] == 10) {

                            finalScore -= sFrame10Point2[0];

                        }
                    
                    }


                    tx2.text = finalScore.ToString();
                    tx3.text = finalScore.ToString();
                    

                }

            }

        }

        //プレイヤー1
        if(turn == 0) {
            
            //スコアが決定し、9フレームじゃないなら
            if(scoreComfirmed == true && turn <= 8) {

                //スコアリストが2以上なら
                if(player1Score.Count > 2) {

                    //2フレーム前がストライクか
                    if(player1Score[frame-2][0] == 0) {
                        
                        //1フレーム前がストライクか
                        if(player1Score[frame-1][0] == 0) {

                            player1Score[frame-2][1] += player1Score[frame-1][1];

                            //現在のフレームはストライクか
                            if(player1Score[frame][0] == 0) {

                                player1Score[frame-2][1] += player1Score[frame][1];

                            //スペアかどうか
                            } else if(player1Score[frame][0] == 1) {

                                int hoge = m.GetSecondPinsCount();
                            
                                player1Score[frame-2][1] += 10 - hoge; 
                            
                            }else {

                                int hoge = player1Score[frame][1] - score;

                                if(hoge <= 0) {

                                    hoge = 0;

                                }

                                player1Score[frame-2][1] += hoge;

                            }
                        
                        //ストライクじゃないなら
                        } else {
                            
                            player1Score[frame-2][1] += player1Score[frame-1][1];

                        }
                     
                    }

                } 
                
                if(player1Score.Count > 1) {

                    //一個前の要素がスペアなら
                    if(player1Score[frame-1][0] == 1) {
                        
                        //ストライクなら
                        if(player1Score[frame][0] == 0) {

                            player1Score[frame-1][1] += player1Score[frame][1];

                        //スペアなら
                        } else if(player1Score[frame][0] == 1) {

                            int hoge = m.GetSecondPinsCount();
                            
                            player1Score[frame-1][1] += 10 - hoge;

                        } else {
                            
                            int hoge = player1Score[frame][1] - score;

                            if(hoge <= 0) {

                                hoge = 0;

                            }

                            player1Score[frame-1][1] += hoge;

                        }
                    }

                }
            }

        //プレイヤー2
        } else {

            //スコアが決定し、9フレームじゃないなら
            if(scoreComfirmed == true && turn <= 8) {

                //スコアリストが2以上なら
                if(player2Score.Count > 2) {

                    //2フレーム前がストライクか
                    if(player2Score[frame-2][0] == 0) {
                        
                        //1フレーム前がストライクか
                        if(player2Score[frame-1][0] == 0) {

                            player2Score[frame-2][1] += player2Score[frame-1][1];

                            //現在のフレームはストライクか
                            if(player2Score[frame][0] == 0) {

                                player2Score[frame-2][1] += player2Score[frame][1];

                            } else if(player2Score[frame][0] == 1) {

                                int hoge = m.GetSecondPinsCount();
                            
                                player2Score[frame-2][1] += 10 - hoge; 
                            
                            } else {

                                int hoge = player2Score[frame][1] - score;

                                if(hoge <= 0) {

                                    hoge = 0;

                                }

                                player2Score[frame-2][1] += hoge;

                            }
                        
                        //ストライクじゃないなら
                        } else {
                            
                            player2Score[frame-2][1] += player2Score[frame-1][1];

                        }
                     
                    }

                } 
                
                if(player2Score.Count > 1) {
                    
                    //一個前の要素がスペアなら
                    if(player2Score[frame-1][0] == 1) {
                        
                        //ストライクなら
                        if(player2Score[frame][0] == 0) {

                            player2Score[frame-1][1] += player2Score[frame][1];

                        //スペアなら
                        } else if(player2Score[frame][0] == 1) {

                            int hoge = m.GetSecondPinsCount();
                            
                            player2Score[frame-1][1] += 10 - hoge;

                        } else {
                            
                            int hoge = player2Score[frame][1] - score;

                            if(hoge <= 0) {

                                hoge = 0;

                            }

                            player2Score[frame-1][1] += hoge;

                        }
                    }

                }
            }
        }

        if(scoreComfirmed == true) {
            
            GenerateGedanText(frame, turn);
        
        }

        scoreComfirmed = false;

    }

    void GenerateGedanText(int frame, int turn) {

        //プレイヤー1
        if(turn == 0) {
            
            if(player1Score.Count > 2) {

                //ストライクなら
                if(player1Score[frame-2][0] == 0) {
                    
                    int totalScore = 0;

                    for(int i = 0; i < player1Score.Count-2; i++) {

                        totalScore += player1Score[i][1];

                    }

                    texts1[frame-2].GetComponent<Text>().text = totalScore.ToString();

                    //ストライクでもスペアでもないなら
                    if(player1Score[frame-1][0] == 2) {

                        totalScore += player1Score[player1Score.Count-2][1];
                    
                        texts1[frame-1].GetComponent<Text>().text = totalScore.ToString();

                    } 
            
                }

            
            }  
            
            //要素が1以上あるなら
            if(player1Score.Count > 1) {
                
                //スペアなら
                if(player1Score[frame-1][0] == 1) {
                    
                    int totalScore = 0;

                    for(int i = 0; i < player1Score.Count-1; i++) {

                        totalScore += player1Score[i][1];

                    }
                                        
                    texts1[frame-1].GetComponent<Text>().text = totalScore.ToString();

                    //ストライクでもスペアでもないなら
                    if(player1Score[frame][0] == 2) {

                        totalScore += player1Score[frame][1];

                        texts1[frame].GetComponent<Text>().text = totalScore.ToString();
                    
                    }

                } else {

                    //現在のフレームのスコアがストライクかスペアじゃないなら
                    if(player1Score[frame][0] == 2 && player1Score[frame-1][0] == 2) {

                        int totalScore = 0;

                        for(int i = 0; i < player1Score.Count; i++) {

                            totalScore += player1Score[i][1];

                        }

                        texts1[frame].GetComponent<Text>().text = totalScore.ToString();
                    }

                }

            }

            //要素が1なら
            if(player1Score.Count == 1) {

                //ストライクでもスペアでもないなら
                if(player1Score[frame][0] == 2) {

                    texts1[frame].GetComponent<Text>().text = player1Score[frame][1].ToString();

                }

            }

        //プレイヤー2
        } else {
            
            if(player2Score.Count > 2) {

                //ストライクなら
                if(player2Score[frame-2][0] == 0) {
                    
                    int totalScore = 0;

                    for(int i = 0; i < player2Score.Count-2; i++) {

                        totalScore += player2Score[i][1];

                    }

                    texts2[frame-2].GetComponent<Text>().text = totalScore.ToString();
     
                    //ストライクでもスペアでもないなら
                    if(player2Score[frame-1][0] == 2) {
                        
                        totalScore += player2Score[player2Score.Count-2][1];

                        texts2[frame-1].GetComponent<Text>().text = totalScore.ToString();

                    } 
            
                }

            
            }  
            
            //要素が1以上あるなら
            if(player2Score.Count > 1) {
                
                //スペアなら
                if(player2Score[frame-1][0] == 1) {
                    
                    int totalScore = 0;

                    for(int i = 0; i < player2Score.Count-1; i++) {

                        totalScore += player2Score[i][1];

                    }
                                        
                    texts2[frame-1].GetComponent<Text>().text = totalScore.ToString();

                    //ストライクでもスペアでもないなら
                    if(player2Score[frame][0] == 2) {

                        totalScore += player2Score[frame][1];

                        texts2[frame].GetComponent<Text>().text = totalScore.ToString();
                    
                    }

                } else {

                    //現在のフレームのスコアがストライクかスペアじゃないなら
                    if(player2Score[frame][0] == 2 && player2Score[frame-1][0] == 2) {

                        int totalScore = 0;

                        for(int i = 0; i < player2Score.Count; i++) {

                            totalScore += player2Score[i][1];

                        }

                        texts2[frame].GetComponent<Text>().text = totalScore.ToString();
                    }

                }

            }

            //要素が1なら
            if(player2Score.Count == 1) {

                //ストライクでもスペアでもないなら
                if(player2Score[frame][0] == 2) {

                    texts2[frame].GetComponent<Text>().text = player2Score[frame][1].ToString();

                }

            }

        }

    }

}
