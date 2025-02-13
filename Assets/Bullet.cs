using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 3.0f;
    public float Speed {
        get { return this.speed; }
        private set { this.speed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if(transform.position.y > 6.0){
            Destroy(gameObject);
        }
    }
}
