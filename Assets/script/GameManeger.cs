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


    //�X�^�[�g���\�b�h
    public void StartGame()
    {
        SceneDate.score = 0;
        SceneManager.LoadScene("GameScene");
    }

    //�G���h���\�b�h
    public void EndGame()
    {
        //�l�������X�R�A�ƃ��U���g��ʂ֑J��
        SceneDate.score = ScoreScript.instance.GetCurrentScore();

        SceneManager.LoadScene("ResultScene");
    }
}
