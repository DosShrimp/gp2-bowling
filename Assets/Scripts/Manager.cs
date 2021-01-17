using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public EnemyManager em;
    public GameObject gcText;
    public float count = 2;

    public GameObject player;
    Rigidbody rb;
    Shot shot;

    public GameObject zanki1;
    public GameObject zanki2;
    public GameObject zanki3;
    bool z1IsDestroyed = false;
    bool z2IsDestroyed = false;
    bool z3IsDestroyed = false;

    public GameObject goText;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        shot = player.GetComponent<Shot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shot.isShoted) {
            
            if(em.isClear) {

                count -= 1 * Time.deltaTime;

                if(count < 0) {
                    count = 0;
                    gcText.SetActive(true);
                }

            }else if(rb.IsSleeping()) {
                
                count -= 1 * Time.deltaTime;
                
                if(count < 0) {
                                        
                    if(z1IsDestroyed == false) {

                        Destroy(zanki1);
                        z1IsDestroyed = true;
                        shot.reset();
                        count = 1;

                     } else if(z2IsDestroyed == false) {

                        Destroy(zanki2);
                        z2IsDestroyed = true;
                        shot.reset();
                        count = 1;

                    } else if(z3IsDestroyed == false) {

                        Destroy(zanki3);
                        z3IsDestroyed = true;                        
                    
                    }

                    if(z3IsDestroyed) {

                        goText.SetActive(true);
                        count = 0;

                        if(Input.GetKeyDown("t")) {

                            SceneManager.LoadScene("title");

                        } else if(Input.GetKeyDown("r")) {
                            
                            Scene loadScene = SceneManager.GetActiveScene();
                            SceneManager.LoadScene(loadScene.name);

                        }
                    
                    }


                }

 
                
                       
            }
        }
        
    }
}
