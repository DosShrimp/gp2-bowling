using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public bool isClear = false;
    
    Wall i_wall;
    private List<GameObject> i_enemies = new List<GameObject>();
    private List<bool> judges = new List<bool>();
    Scene loadScene;

    // Start is called before the first frame update
    void Start()
    {
         loadScene = SceneManager.GetActiveScene();

        if(loadScene.name == "Stage1") {

            i_enemies.Add(Instantiate(enemy, new Vector3(0.0f, 30.0f, 48.0f), Quaternion.identity));
            
            i_wall = i_enemies[0].GetComponent<Wall>();
            judges.Add(i_wall.judge);
            
        } else if(loadScene.name == "Stage2") {
            
            for(int i = 0; i < 3; i++) {

                i_enemies.Add(Instantiate(enemy, new Vector3(0.0f, 30.0f, 48.0f + 10.0f * i), Quaternion.identity));
                
                i_wall = i_enemies[i].GetComponent<Wall>();
                judges.Add(i_wall.judge);
                Debug.Log(judges[i]);
            }
        
        }
    }

    // Update is called once per frame
    void Update()
    {   

        for(int i = 0; i < 3; i++) {
            Debug.Log(judges[i]);
        }



        // if(judges.All(i => i == true)) {
        //     Debug.Log("YO!");
        //     isClear = true;
            
        // }
        
    }
}
