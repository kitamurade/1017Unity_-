using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneData;
public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance { get; private set; }
    public int score { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //スタートメソッド
    public void StartGame()
    {
        SceneDate.score = 0;
        SceneManager.LoadScene("GameScene");
    }

    //エンドメソッド
    public void EndGame()
    {
        //獲得したスコアとリザルト画面へ遷移
        SceneDate.score = ScoreScript.instance.GetCurrentScore();

        SceneManager.LoadScene("ResultScene");
    }
}
