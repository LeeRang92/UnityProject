using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// 안드로이드 백키 눌렀을 때 실행, 시간 점수 text, 점프 상태 변경 버튼
	public GameObject backMenu, timeCount, jumpStateBtn; 
	public GameObject jumpBtn, micJump; // 점프 버튼, voice 점프
	public GameObject finishMenu;

	public AudioSource bgm;
	public static UIManager instance;

	int jumState = 0; // 점프 상태 버튼 클릭
	int click = 0; // 일시정지 버튼 클릭 횟수

	void Awake(){
		instance = this;
		backMenu.SetActive (false);
		finishMenu.SetActive (false);
		
		if (jumState == 0) {
			jumpBtn.SetActive (false);
			jumState++;
		}
	}

	void Update () {
		//안드로이드 백버튼 실행
		if(Application.platform == RuntimePlatform.Android){
			if(Input.GetKey(KeyCode.Escape)){
				backMenu.SetActive(true);
				Time.timeScale = 0f;
			}
		}
	}
	// 점프 상태 변경
	public void ChangeJumpState(){
		if (jumState==0) {
			jumpBtn.SetActive (false);
			micJump.SetActive (true);
			jumState++;
		} else if (jumState>=1) {
			micJump.SetActive (false);
			jumpBtn.SetActive (true);
			jumState=0;
		}
	}
	//일시 정지
	public void Pause(){
		if (click >= 1) {
			Time.timeScale = 1f;
			click = 0;
		}else {
			Time.timeScale = 0f;
			click++;
		}
	}
	// 게임으로 돌아가기
	public void ReturnGame(){
		backMenu.SetActive (false);
		Time.timeScale = 1f;
		timeCount.SetActive (true);
	}
	// 게임 재시작
	public void ResetGame(){
		Application.LoadLevel ("InGame");
		TimeCount_UI.time = 0f;
		Time.timeScale = 1f;
	}

	//사망 메뉴 생성
	public void SetFinishMenu(){
		timeCount.SetActive (false);
		finishMenu.SetActive (true);
		Time.timeScale = 0f;
	}
	// 타이틀 화면으로 돌아가기
	public void GetOutTitle(){
		Time.timeScale = 1f;
		Application.LoadLevel ("Title");
	}
	public void getScore(){
		RankingManager.rankScore.Add (TimeCount_UI.time);
	}

}
