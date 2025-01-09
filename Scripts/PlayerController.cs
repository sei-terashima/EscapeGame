using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charaCnt; //操作
    private Vector3 moveDirection; //3軸
    public float gravity;  // 重力の強さ
    public float speedZ;  // 前後の移動速度
    public int speedJump;  // ジャンプの力
    public float stunDuration;  // スタン時間
    private float recoverTime;  // 復帰までの時間
    public int life;  // プレイヤーのライフ

    void Start()
    {
        // CharacterControllerの取得
        charaCnt = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ゲームが終了している場合
        if (GameManager.gameState == "GameEnd")
        {
            return;
        }

        // ゲームクリアの場合
        if (GameManager.gameState == "GameClear")
        {
            // 重力を無効、操作無効
            moveDirection.y = 0.0f;
            charaCnt.enabled = false;
            //CapselColiderコンポーネントを無効
            GetComponent<CapsuleCollider>().enabled = false;
            return;
        }

        // ライフが0以下の場合
        if (life <= 0.0f)
        {
            // ゲームオーバーにし、自身を破棄
            GameManager.gameState = "GameOver";
            Destroy(this.gameObject);
            return;
        }

        // スタン状態の場合
        if (IsStun())
        {
            // 移動を停止し、復帰時間を減少
            moveDirection.x = 0.0f;
            moveDirection.y = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            // 地面にいる場合
            if (charaCnt.isGrounded)
            {
                    //前後の入力処理
                    moveDirection.z = Input.GetAxis("Vertical") * speedZ;

                // 左右の入力処理（回転）
                transform.Rotate(0, Input.GetAxis("Horizontal") * 2, 0);

                if (Input.GetButton("Jump"))
                {
                    // ジャンプの入力処理
                    moveDirection.y = speedJump;
                }
            }
            // 重力の適用
            moveDirection.y -= gravity * Time.deltaTime;

            //移動
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            charaCnt.Move(globalDirection * Time.deltaTime);

            // 地面にいる場合、前後の移動を停止
            if (charaCnt.isGrounded) moveDirection.y = 0.0f;
        }
    }

    // スタン状態の判定
    bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0.0f;
    }

    void OnTriggerEnter(Collider hit)
    {
        // スタン状態の場合は何もしない
        if (IsStun()) return;

        // トラップに衝突した場合
        if (hit.gameObject.tag == "Trap")
        {
            // ライフを減少させ、回復時間をリセット
            life--;
            recoverTime = stunDuration;
            // トラップのエフェクトを発動し、トラップを消滅させる
            hit.GetComponent<Trap>().CreateEffect();
            Destroy(hit.gameObject);
        }
    }
}
