using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerator : MonoBehaviour
{
    public GameObject TrapPrefab; //プレハブ
    public float interval; //生成間隔


    // スタートメソッドで間隔を決めたリピートを開始
    void Start()
    {
        InvokeRepeating("CreateTrap", 0.0f, interval);
    }

    //CreateTrapメソッド
    void CreateTrap()
    {
        //それぞれの位置を設定(x(横:範囲内ランダム),y(高さ:8.0f固定),z(奥行:範囲内ランダム)
        Vector3 randomPosition = new Vector3
            (Random.Range(-1.6f, 4.5f), 8.0f, Random.Range(-4.5f, 5.6f));
        //指定したオブジェクトを上記で指定した場所に回転なしで生成
        Instantiate(TrapPrefab, randomPosition, Quaternion.identity);
    }
}
