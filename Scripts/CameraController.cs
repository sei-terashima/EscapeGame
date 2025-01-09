using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 diff; //プレイヤーとカメラの距離
    public GameObject target; //プレイヤー
    public float followSpeed; //カメラスピード


    // Start is called before the first frame update
    void Start()
    {
        diff = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //プレイヤーがいれば
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position - diff, followSpeed * Time.deltaTime);
        }
        }
}
