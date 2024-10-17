using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCamera : MonoBehaviour
{
    //�e��I�u�W�F�N�g
    public Camera MainCamera;
    public Camera EffectCamera;
    public float transitionDuration = 5.0f;
    //�J�����̍��W
    public Vector3 startPosition = new Vector3(0, 0, 3);
    public Vector3 endPosition = new Vector3(0, 5, -10);
    //�^�C�}�[�X�N���v�g���C���X�^���X��
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
        //���o�p�̃J������L�������ă��C���J�����𖳌�������
        MainCamera.enabled = false;
        EffectCamera.enabled = true;

        //�J�n���̈ʒu��ݒ�
        EffectCamera.transform.position = startPosition;

        //�o�ߎ���
        float elapsedTime = 0.0f;
        //���o���ԁi�o�ߎ��Ԃ��I�����ԂɂȂ�܂Łj
        while(elapsedTime < transitionDuration)
        {
            //Lerap�֐��ňʒu���Ԃ��Ĉړ�
            EffectCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime/transitionDuration);
            elapsedTime += Time.deltaTime;
            //���̃t���[���܂őҋ@
            yield return null;
        }
        //�J�����̈ʒu���I���ʒu�Ɏ����Ă���
        EffectCamera.transform.position = endPosition;

        //���C���J������L�������ĉ��o�J�����𖳌���
        EffectCamera.enabled=false;
        MainCamera.enabled = true;

        //���o���I�������^�C�}�[�J�n
        if(timerController!=null)
        {
            timerController.StartTimer();
        }
    }
}
