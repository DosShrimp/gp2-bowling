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

    public float[,] pinLocations = new float[,] { 
        {0.0f, 0.0f, 40.0f}, 
        {-1.0f, 0.0f, 43.0f}, 
        {1.0f, 0.0f, 43.0f}, 
        {-2.0f, 0.0f, 46.0f}, 
        {0.0f, 0.0f, 46.0f}, 
        {2.0f, 0.0f, 46.0f}, 
        {-3.0f, 0.0f, 49.0f}, 
        {-1.0f, 0.0f, 49.0f}, 
        {1.0f, 0.0f, 49.0f}, 
        {3.0f, 0.0f, 49.0f} 
    };



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

        for(int i = 0; i < 10; i++) {
            
            firstPins.Add(Instantiate(pin, new Vector3(pinLocations[i , 0], pinLocations[i , 1], pinLocations[i , 2]), Quaternion.identity));
            firstScripts.Add(firstPins[i].GetComponent<Collapse>());

        }
       
    }
    
}
