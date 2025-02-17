using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererOnOff : MonoBehaviour
{
    [SerializeField]private Renderer target;
    [SerializeField]private float cycle = 0.4f;
    private double time;
    private bool isBlinking = false;
    public bool IsBlinking {
        get { return this.isBlinking; }
        private set { this.isBlinking = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BeginBlink()
    {
        if(this.IsBlinking) return;

        this.IsBlinking = true;

        //内部時間初期化
        this.time = 0;

        Invoke("EndBlink", 3.0f);
    }

    public void EndBlink(){
        Debug.Log("点滅終了");
        this.IsBlinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!this.IsBlinking) return;

        //内部時間加算
        this.time += Time.deltaTime;

        //cycle周期の値
        var repeatValue = Mathf.Repeat((float)time, cycle);

        //timeにおける明滅状態反映
        this.target.enabled = repeatValue >= cycle * 0.1f;
    }
}
