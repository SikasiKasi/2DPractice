using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    public float Speed {
        get { return speed; }
        private set { speed = value; }
    }

    private int hp = 1;
    public int Hp {
        get { return this.hp; }
        private set { this.hp = value; }
    }
    private bool Right = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 4){
            transform.Translate(0, this.Speed * Time.deltaTime, 0);
        } else {
            if(this.Right){
                Debug.Log("右");
                transform.Translate(-this.Speed * Time.deltaTime, 0, 0);
            } else {
                Debug.Log("左");
                transform.Translate(this.Speed * Time.deltaTime, 0, 0);
            }
        }
        
        if(transform.position.x > 2.25) this.Right = false;
        else if(transform.position.x < -2.25) this.Right = true;

        if(transform.position.y < -6.0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突");
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
