using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    //倒した敵の数
    private int counter = 0;
    [SerializeField] private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenEnemy", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenEnemy() 
    {
        GameObject o = Instantiate(EnemyPrefab);
        
        //GetComprnentでEnemyのスクリプト取得
        Enemy enemy = o.GetComponent<Enemy>();
        
        //SetUp(フィールドのbulletManagerにセットするだけ)を呼び出し
        enemy.SetUp(bulletManager);
        enemy.SetLayer("Enemy");
        
        //出現位置調整
        enemy.transform.position = new Vector3(Random.Range(-3, 3), 9, 0);
        enemy.transform.eulerAngles = new Vector3(0, 0, 180);
    }
}
