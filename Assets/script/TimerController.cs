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
    //�ꎞ��~�^�C�}�[
    private bool isPoused = true;

    // Update is called once per frame
    void Update()
    {
        //�ꎞ��~�Ń^�C�}�[�J�E���g�����s���Ȃ�
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
