using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GenEnemy", 1, 1);
        GenEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenEnemy() 
    {
        Instantiate(EnemyPrefab, new Vector3(0, 9, 0), Quaternion.Euler(0f, 0f, 180f));
    }
}
