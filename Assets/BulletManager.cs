using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    ObjectPool<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ObjectPoolコンストラクタの1つ目の引数
    //objectpool.Get()で呼ばれる
    //プールに空きがないとき(生成する必要があるとき)に呼ばれる
    GameObject OnCreatePoolObject()
    {
        GameObject o = Instantiate(BulletPrefab);
        return o;
    }

    //コンストラクタ2つ目の引数
    //プールに空きがあるときの処理
    //objectPool.Get()の時呼ばれる
    void OnTakeFromPool(GameObject target)
    {
        target.SetActive(true);
    }

    //コンストラクタ3つ目の引数
    //プールに返却する
    //objectPool.Release()で呼ばれる
    void OnReturnedToPool(GameObject target)
    {
        target.SetActive(false);
    }

    //コンストラクタ4つ目の引数
    //プールの許容量を超えたときの削除処理
    void OnDestroyPoolObject(GameObject target){
        Destroy(target);
    }

    //プレイヤーやエネミーから呼び出して弾を発生させる
    public GameObject GetBullet()
    {
        GameObject o = pool.Get();
        return o;
    }

    //弾から呼び出して弾を消滅させる
    public void DelBullet(GameObject target)
    {
        pool.Release(target);
    }
}
