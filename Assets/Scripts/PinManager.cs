using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinManager : MonoBehaviour
{
    public Manager m;
    public GameObject pin;
    
    public List<GameObject> firstPins = new List<GameObject>();
    public List<Collapse> firstScripts = new List<Collapse>();

    List<GameObject> secondPins;
    public List<Collapse> secondScripts = new List<Collapse>();


    public bool generated = false;


    // Start is called before the first frame update
    void Start()
    {

        secondPins = m.secondPins;

    }

    // Update is called once per frame
    void Update()
    {   
        //一回目か？&&生成してないか？
        if(m.first_throw && !generated) {

            FirstGenerate();
            generated = true;

        //二回目か？&&生成してないか？
        } else if(m.second_throw && !generated) {
            
            if(secondPins != null && secondPins.Count > 0) {

                for(int i = 0; i < secondPins.Count; i++) {

                    //二回目の投げのピンたちはCollapseコンポーネントを持っているのか？
                    if(secondPins[i].GetComponent<Collapse>() != null) {
                
                        secondPins[i].GetComponent<Collapse>().enabled = true;
                                
                        secondScripts.Add(secondPins[i].GetComponent<Collapse>());
                
                    }   

                }

                generated = true;

            }

        }
        
    }

    void FirstGenerate() {
        //1ピン目
        firstPins.Add(Instantiate(pin, new Vector3(0.0f, 3.0f, 40.0f), Quaternion.identity));
        firstScripts.Add(firstPins[0].GetComponent<Collapse>());

        //2ピン目
        firstPins.Add(Instantiate(pin, new Vector3(-1.0f, 3.0f, 45.0f), Quaternion.identity));
        firstScripts.Add(firstPins[1].GetComponent<Collapse>());

        //3ピン目
        firstPins.Add(Instantiate(pin, new Vector3(1.0f, 3.0f, 45.0f), Quaternion.identity));
        firstScripts.Add(firstPins[2].GetComponent<Collapse>());

        //4ピン目
        firstPins.Add(Instantiate(pin, new Vector3(-2.0f, 3.0f, 50.0f), Quaternion.identity));
        firstScripts.Add(firstPins[3].GetComponent<Collapse>());

        //5ピン目
        firstPins.Add(Instantiate(pin, new Vector3(0.0f, 3.0f, 50.0f), Quaternion.identity));
        firstScripts.Add(firstPins[4].GetComponent<Collapse>());

        //6ピン目
        firstPins.Add(Instantiate(pin, new Vector3(2.0f, 3.0f, 50.0f), Quaternion.identity));
        firstScripts.Add(firstPins[5].GetComponent<Collapse>());

        //7ピン目
        firstPins.Add(Instantiate(pin, new Vector3(-3.0f, 3.0f, 55.0f), Quaternion.identity));
        firstScripts.Add(firstPins[6].GetComponent<Collapse>());

        //8ピン目
        firstPins.Add(Instantiate(pin, new Vector3(-1.0f, 3.0f, 55.0f), Quaternion.identity));
        firstScripts.Add(firstPins[7].GetComponent<Collapse>());

        //9ピン目
        firstPins.Add(Instantiate(pin, new Vector3(1.0f, 3.0f, 55.0f), Quaternion.identity));
        firstScripts.Add(firstPins[8].GetComponent<Collapse>());

        //9ピン目
        firstPins.Add(Instantiate(pin, new Vector3(3.0f, 3.0f, 55.0f), Quaternion.identity));
        firstScripts.Add(firstPins[9].GetComponent<Collapse>());
    }
    
}
