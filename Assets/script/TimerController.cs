using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public GameObject timeText;
    public string nextSceneName;
    public float transitionTime = 10f;

    private float elapsedTime = 0f;
    //一時停止タイマー
    private bool isPoused = true;

    // Update is called once per frame
    void Update()
    {
        //一時停止でタイマーカウントを実行しない
        if(isPoused)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        UpdatetimeText();

        if (elapsedTime >= transitionTime)
        {
            GameManeger.Instance.EndGame();
        }

    }

    private void UpdatetimeText()
    {
        this.timeText.GetComponent<TextMeshProUGUI>().text = "Time:" + elapsedTime.ToString("F2") + " Sec";
    }

    public void StartTimer()
    {
        isPoused = false;
    }
    public void PausedTimer()
    {
        isPoused = true;
    }
}
