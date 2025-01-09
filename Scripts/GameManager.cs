using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player; //プレイヤーコントローラー
    // メインテキストオブジェクト
    public GameObject mainText; //状態の表示をするテキスト
    public LifePanel lifePanel; //体力表示用
    public TextMeshProUGUI timeText; //時間表示
    public float gameTime; //時間計算
    public static string gameState; //状態を管理する変数

    void Start()
    {
        gameState = "Playing"; //ステータスを"Playing"に変更
        // ライフパネルの内容を更新
        lifePanel.UpdateLife(player.life);
        // 2秒後にメインテキストを非表示にする
        Invoke("HideMainText", 2.0f);
    }

    void Update()
    {
        // ゲーム終了状態なら何もしない
        if (gameState == "GameEnd") return;

        // 常にライフパネルを更新
        lifePanel.UpdateLife(player.life);

        // ゲームオーバー状態の処理
        if (gameState == "GameOver")
        {
            // メインテキストを"Game Over"に設定し表示
            mainText.GetComponent<TextMeshProUGUI>().text = "GAME OVER";
            mainText.SetActive(true);
            // ゲームステータスを"GameEnd"に設定
            gameState = "GameEnd";
            // 3秒後にタイトルシーンに移動
            Invoke("ChangeScene", 3.0f);
            return;
        }

        // ゲームクリア状態の処理
        if (gameState == "GameClear")
        {
            // メインテキストを"Game Clear"に設定し表示
            mainText.GetComponent<TextMeshProUGUI>().text = "GAME CLEAR";
            mainText.SetActive(true);
            // ゲームステータスを"GameEnd"に設定
            gameState = "GameEnd";
            // 3秒後にタイトルシーンに移動
            Invoke("ChangeScene", 3.0f);
            return;
        }

        // ゲームタイムの更新（カウントダウン）
        gameTime -= Time.deltaTime;
        // 現在のタイムをテキストに表示（切り上げ）
        timeText.text = "TIME: " + Mathf.Ceil(gameTime).ToString();

        // ゲームタイムが0以下ならゲームクリアに設定
        if (gameTime <= 0)
        {
            gameState = "GameClear";
        }
    }

    // メインテキストを非表示にするメソッド
    void HideMainText()
    {
        mainText.SetActive(false);
    }

    // タイトルシーンに移動するメソッド
    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
