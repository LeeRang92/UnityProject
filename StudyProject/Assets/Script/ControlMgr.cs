using UnityEngine;
using System.Collections;

public class ControlMgr : MonoBehaviour {

    public bool switchControl = false;

    private int btnCount = 0;

    public static ControlMgr instance;

    void Awake()
    {
        instance = this;
    }

	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Z)){
            //고래 컨트롤
            if(btnCount <= 0)
            {
                switchControl = true;
                btnCount++;
            }
            //캐릭터 컨트롤
            else
            {
                switchControl = false;
                btnCount = 0;
            }
            StartCoroutine("SwitchSpeed");
        }
	}

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
