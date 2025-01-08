using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    // 子オブジェクトのイメージを格納
    public GameObject[] icons;

    // プレイヤーのライフに応じてアイコンを更新
    public void UpdateLife(int life)
    {
        // アイコンの数だけ繰り返し処理を行う
        for (int i = 0; i < icons.Length; i++)
        {
            // 現在のライフでアイコンを変更
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
