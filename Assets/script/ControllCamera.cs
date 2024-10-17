using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCamera : MonoBehaviour
{
    //各種オブジェクト
    public Camera MainCamera;
    public Camera EffectCamera;
    public float transitionDuration = 5.0f;
    //カメラの座標
    public Vector3 startPosition = new Vector3(0, 0, 3);
    public Vector3 endPosition = new Vector3(0, 5, -10);
    //タイマースクリプトをインスタンス化
    public TimerController timerController;
    // Start is called before the first frame update
    void Start()
    {
        if(timerController != null)
        {
            timerController.PausedTimer();
        }
        StartCoroutine(CameraTransition());
    }

    private IEnumerator CameraTransition()
    {
        //演出用のカメラを有効化してメインカメラを無効化する
        MainCamera.enabled = false;
        EffectCamera.enabled = true;

        //開始時の位置を設定
        EffectCamera.transform.position = startPosition;

        //経過時間
        float elapsedTime = 0.0f;
        //演出時間（経過時間が終了時間になるまで）
        while(elapsedTime < transitionDuration)
        {
            //Lerap関数で位置を補間して移動
            EffectCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime/transitionDuration);
            elapsedTime += Time.deltaTime;
            //次のフレームまで待機
            yield return null;
        }
        //カメラの位置を終了位置に持ってくる
        EffectCamera.transform.position = endPosition;

        //メインカメラを有効化して演出カメラを無効化
        EffectCamera.enabled=false;
        MainCamera.enabled = true;

        //演出が終わったらタイマー開始
        if(timerController!=null)
        {
            timerController.StartTimer();
        }
    }
}
