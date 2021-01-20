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

        //一回目の投げか？   
        if(first_throw) {   


            //ボールが奥に着いたか？&&すべてのピンが止まったか？
            if(th.arrived && firstPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                //ストライクか？
                if(firstScripts.All(i => i.judge == true)) {

                    Debug.Log("ストライク！！");

                    for(int j = 0; j < firstPins.Count; j++) {

                        secondPins.Add(firstPins[j]);
                        Destroy(firstPins[j]);

                    }


                    firstPins.Clear();
                    firstScripts.Clear();

                    pm.generated = false;
                    th.Reset();

                } else {
                    
                    //ピンの状態を確かめるぞ
                    for(int j = 0; j < firstPins.Count; j++) {
                        
                        //ピンはまだ立っているか？
                        if(!firstScripts[j].judge) {

                            //二回目のピンのセット
                            secondPins.Add(firstPins[j]);
                            Destroy(firstPins[j]);

                        } else {
                            
                            Destroy(firstPins[j]);

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
                
            // Debug.Log("ヤーヤーヤー");


                //ボールが奥に着いたか？&&すべてのピンが止まったか？
                if(th.arrived && secondPins.All(i => i.GetComponent<Rigidbody>().IsSleeping())) {

                    //スペアか？
                    if(secondScripts.All(i => i.judge == true)) {
                
                        Debug.Log("スペアや！");

                    } else {
                
                    //２回目で倒したピン数える

                    }


                //また１回目の投げから

                }

        }
        
    }
}
