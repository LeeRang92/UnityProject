using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{

    public Transform playerTr;
    public Transform sheepTr;

    public float speed = 100f;

    private Transform targetTr;
    Transform tr;

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
        if (ControlMgr.instance.switchControl)
        {
            targetTr = sheepTr;
        }
        else {
            targetTr = playerTr;
        }

        tr.position = Vector3.Lerp(tr.position,
                targetTr.position - (targetTr.right * -5.0f) + (targetTr.up * 2.5f) + (targetTr.forward * -1.2f),
               Time.deltaTime * speed);
        
        //타겟을 봐라봄(LookAt과 같음)
        Vector3 dir = targetTr.position - tr.position;
        Quaternion drot = Quaternion.LookRotation(dir);
        Quaternion rot = Quaternion.Slerp(tr.rotation, drot, Time.deltaTime * speed);
        transform.rotation = rot;

        Debug.Log(speed);
    }
}
