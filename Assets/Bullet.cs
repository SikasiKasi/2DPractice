using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 7.0f;
    [SerializeField] private BulletManager bulletManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.speed * Time.deltaTime, 0);

        if(transform.position.y > 8.0 || transform.position.y < -8.0 || transform.position.x > 4.0 || transform.position.x < -4.0){
            bulletManager.DelBullet(gameObject);
            //gameObject.SetActive(false);
        }
    }

    public void SetUp(BulletManager manager)
    {
        bulletManager = manager;
    }

    
}
