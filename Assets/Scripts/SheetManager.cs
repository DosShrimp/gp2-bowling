using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheetManager : MonoBehaviour
{

    int[][] score;
    public Manager m;
    public GameObject text;
    public GameObject tp;

    // Start is called before the first frame update
    void Start()
    {
        score = m.score;
        
    }

    public void GenerateText(bool player1, int frame) {

        float height = 30.0f;

        GameObject o = Instantiate(text);

        RectTransform rt = o.GetComponent(typeof (RectTransform)) as RectTransform;

        Text tx = o.GetComponent<Text>(); 


        if(player1) {
            height = 30.0f;
            rt.transform.SetParent(tp.transform);
            rt.transform.localPosition = new Vector3(-130, height, 0);
            
            var list = new List<int>(score[0]);
            
            tx.text = list[frame].ToString();
        
        } else {
            height = 60.0f;
            rt.transform.SetParent(tp.transform);
            rt.transform.localPosition = new Vector3(-130, height, 0);
            
            var list = new List<int>(score[1]);

            tx.text = list[frame].ToString();

        }

    }

}
