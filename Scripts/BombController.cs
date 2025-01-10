using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private AudioSource audioSource; // オーディオソース
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // オーディオソースを取得
        audioSource.Play(); // 効果音を再生
        Destroy(gameObject,2.5f);
    }

    void Update()
    {
        
    }
}
