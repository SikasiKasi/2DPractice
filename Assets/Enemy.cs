using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;

    private int hp = 5;
    private int BulletCount = 0;
    public int Hp {
        get { return this.hp; }
        private set { this.hp = value; }
    }
    
    public GameObject BuleltPrefab;
    
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

        //弾発射
        if(this.BulletCount == 120){
            //3方向に発射
            Instantiate(this.BuleltPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 180));
            Instantiate(this.BuleltPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 225));
            Instantiate(this.BuleltPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.Euler(0, 0, 135));

            this.BulletCount = (this.BulletCount + 1) % 121;
        } else {
            this.BulletCount = (this.BulletCount + 1) % 121;
        }
        

        if(transform.position.y < -6.0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        Destroy(collision.gameObject);
        this.Hp--;
        if(this.Hp == 0){
            Destroy(gameObject);
        }
        
    }
}
