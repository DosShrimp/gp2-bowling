using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    Wall n;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(0.0f, 30.0f, 48.0f), Quaternion.identity);
        n = enemy.GetComponent<Wall>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(n.judge);
        
    }
}
