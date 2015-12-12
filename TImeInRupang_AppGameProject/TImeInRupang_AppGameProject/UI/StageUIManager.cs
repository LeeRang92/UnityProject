using UnityEngine;
using System.Collections;

public class StageUIManager : MonoBehaviour {

	void Update(){
		if(Application.platform == RuntimePlatform.Android){
			if(Input.GetKey(KeyCode.Escape)){
				Application.LoadLevel("Title");
			}
		}
	}
	
	public void ClickStage1(){ // 과거
		GroundManager.stageNum = 0;
		Application.LoadLevel ("InGame");
	}
	public void ClickStage2(){ // 현재
		GroundManager.stageNum = 1;
		Application.LoadLevel ("InGame");
	}
	public void ClickStage3(){ // 미래
		GroundManager.stageNum = 2;
		Application.LoadLevel ("InGame");
	}
	public void ExitStageMenu(){
		Application.LoadLevel ("Title");
	}
}
