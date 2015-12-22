using UnityEngine;
using System.Collections;

// 캐릭터 컨트롤러(어떤 것을 움직일지)를 변경하기 위한 스크립트

public class ControlMgr : MonoBehaviour {

    public bool switchCtrl = false; // 컨트롤 체크

    public static ControlMgr instance;

    public delegate TResult Func<TArg0, TResult>(TArg0 arg0);

    Func<int, bool> myFunc = x => x == 5;

    void Awake()
    {
        instance = this;
    }

	void Update () {
        //조종할 컨트롤 교체
        if (Input.GetKeyDown(KeyCode.Z)){
            switchCtrl = !switchCtrl;
            StartCoroutine("SwitchSpeed");
        }
	}
    //카메라 전환 시 이동속도 변환
    IEnumerator SwitchSpeed()
    {
        CameraCtrl.instance.speed = 1f;
        while(CameraCtrl.instance.speed <= 20f)
        {
            CameraCtrl.instance.speed += 2f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
