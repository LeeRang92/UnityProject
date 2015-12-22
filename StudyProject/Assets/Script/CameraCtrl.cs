using UnityEngine;
using System.Collections;

//카메라를 제어하기 위한 스크립트

public class CameraCtrl : MonoBehaviour
{

    public Transform playerTr; // 플레이어의 위치값
    public Transform whaleTr;  // 고래의 위치값
    public float speed = 100f; // 카메라의 속도

    private Transform targetTr; // 추적할 타겟의 위치값을 저장
    private Transform tr;

    public static CameraCtrl instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        //추적할 타겟의 Transform값을 바꿈
        if (ControlMgr.instance.switchCtrl)
        {
            targetTr = whaleTr;
        }
        else {
            targetTr = playerTr;
        }
        //타겟 추적
        tr.position = Vector3.Lerp(tr.position,
                targetTr.position - (targetTr.right * -5.0f) + (targetTr.up * 2.5f) + (targetTr.forward * -1.2f),
               Time.deltaTime * speed);
        
        //타겟을 봐라봄(LookAt과 같음)
        Vector3 dir = targetTr.position - tr.position;
        Quaternion drot = Quaternion.LookRotation(dir);
        Quaternion rot = Quaternion.Slerp(tr.rotation, drot, Time.deltaTime * speed);
        transform.rotation = rot;
    }
}
