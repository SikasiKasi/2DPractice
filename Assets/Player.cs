using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public GameObject BuleltPrefab;
    private int BulletCount = 0;
    private float speed = 3.0f;
    private int hp = 10;

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
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("ダッシュボタン");
            this.dash = !this.dash;

            if(this.dash) this.Speed = 6.0f;
            else this.speed = 3.0f;
        }

        //Bullet発射
        if(Input.GetKey(KeyCode.Q)){
            Debug.Log(this.BulletCount);
            if(this.BulletCount == 0 || this.BulletCount == 30){
                Instantiate(this.BuleltPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            }
            this.BulletCount = (this.BulletCount + 1) % 31;
        } else {
            this.BulletCount = 0;
        }

        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * this.speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * this.speed;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + x, -2.25f, 2.25f),
                                         Mathf.Clamp(transform.position.y + y, -4.7f, 4.7f));
    }

    //自機との衝突
    void OnTriggerEnter2D(Collider2D collision)
    {
        var blinker = GetComponent<RendererOnOff>();
        
        //点滅中は無敵
        if(!blinker.IsBlinking){
            this.hp--;
            Debug.Log("被弾 : 残りHP " + this.hp);
            
            if(this.hp == 0){
                Debug.Log("撃墜");
                Destroy(gameObject);
            } else {
                //点滅させる
                blinker.BeginBlink();
            }
        } else {
            Debug.Log("無敵時間");
        }
        
    }
}
