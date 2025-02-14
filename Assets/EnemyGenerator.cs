using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private int hp = 1;
    public int Hp {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenEnemy", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenEnemy() 
    {
        Instantiate(EnemyPrefab, new Vector3(-2.5f + 5 * Random.value, 6, 0), Quaternion.Euler(0f, 0f, 180f));
    }
}
