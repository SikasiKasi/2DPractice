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
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.Speed * Time.deltaTime, 0);

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
