using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{

    public Transform targetTr;
    Transform tr;

    void Start()
    {
        //targetTr = GameObject.Find("unitychan").transform;
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        tr.position = Vector3.Lerp(tr.position, 
            targetTr.position - (targetTr.right * -5.0f) + (targetTr.up * 2.5f) + (targetTr.forward * -1.2f), 
            Time.time);

        tr.LookAt(targetTr.position);
    }
}
