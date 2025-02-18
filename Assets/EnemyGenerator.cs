using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    //倒した敵の数
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenEnemy() 
    {
        //撃破数で管理
        switch(counter){
            case 0:
                Instantiate(EnemyPrefab, new Vector3(0, 9, 0), Quaternion.Euler(0f, 0f, 180f));
                break;
            default:
                break;
        }
        
        
    }
}
