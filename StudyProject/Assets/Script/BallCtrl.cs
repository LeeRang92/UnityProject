using UnityEngine;
using System.Collections;

//고래를 제어하기 위한 스크립트

public class BallCtrl : MonoBehaviour {

    float speed = 3.0f;

    public Transform playerTr;

    private Transform tr;
    private Vector3 moveDir = Vector3.zero;

    CharacterController controller;

	void Start () {
        tr = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
	}
	
	void Update () {
        if (!ControlMgr.instance.switchCtrl)
        {
            controller.enabled = false;

            tr.position = Vector3.Lerp(tr.position,
                playerTr.position - (playerTr.forward * 1.0f) + (playerTr.up * 1.5f),
                Time.deltaTime);
        }
        else
        {
            controller.enabled = true;

            moveDir = new Vector3(0, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            controller.Move(moveDir * Time.deltaTime);
        }

        //중점을 중심으로 회전
        //tr.RotateAround(playerTr.position, Vector3.up, Time.deltaTime * 20f);
        //tr.LookAt(playerTr.position);

        //목표를 봐라보도록 회전시킨다. LookAt과 비슷하다.
        //Vector3 dir = targetTr.position - tr.position;
        //Quaternion drot = Quaternion.LookRotation(dir);

        //Quaternion rot = Quaternion.Slerp(tr.rotation, drot, Time.deltaTime * 20f);
        //transform.rotation = rot;

    }
}
