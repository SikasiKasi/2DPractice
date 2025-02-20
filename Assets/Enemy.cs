using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;

    private int hp = 5;
    private int angle = 0;
    
    [SerializeField] private GameObject BuleltPrefab;
    [SerializeField] private BulletManager bulletManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 6.5){
            transform.Translate(0, this.speed * Time.deltaTime, 0);
        }
    }

    //弾発射は一定間隔で
    void FixedUpdate()
    {
        //弾発射
        //3方向に発射
        //Enemy側のオブジェクトプールによる発射
        GameObject bullet;
        bullet = bulletManager.GetBullet();
        bullet.layer = LayerMask.NameToLayer("Player");
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = new Vector3(0, 0, angle); 

        angle = (angle + 10) % 360;        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        Destroy(collision.gameObject);
        this.hp--;
        if(this.hp == 0){

            Destroy(gameObject);
        }
        
    }

    public void SetUp(BulletManager manager)
    {
        bulletManager = manager;
    }

    public void SetLayer(String layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
    }
}
