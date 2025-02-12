using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;

    //Speedプロパティ
    public float Speed {
        get { return this.speed; }
        private set { this.speed = value; }
    }

    private bool dash = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("ダッシュボタン");
            this.dash = !this.dash;

            if(this.dash) this.Speed = 6.0f;
            else this.speed = 3.0f;
        }

        

        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * this.speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * this.speed;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + x, -2.25f, 2.25f),
                                         Mathf.Clamp(transform.position.y + y, -4.7f, 4.7f));
    }
}
