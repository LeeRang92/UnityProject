using UnityEngine;
using System.Collections;


public class TitleUIManager : MonoBehaviour {
	
	public GameObject rankingMenu, option;
	public GameObject bgTitle, quitGame, speaker; // title->InGame

	void Awake(){
		quitGame.SetActive (false);
		option.SetActive (false);
		rankingMenu.SetActive (false);
		speaker.SetActive (false);
		RankingManager.GetScore ();
	}

	void Update () {
		if(Application.platform == RuntimePlatform.Android){
			if(Input.GetKey(KeyCode.Escape)){
				quitGame.SetActive(true);
			}
		}
	}

	//옵션 메뉴
	public void ClickOption(){
		option.SetActive (true);
	}
	//스테이지 메뉴
	public void ClickTitle(){
		Application.LoadLevel ("StageMenu");
	}
	//랭킹 메뉴
	public void ClickRanking(){
		rankingMenu.SetActive (true);
	}
	//게임 나가기 메뉴
	public void QuitGame(){
		Application.Quit();
	}
	//타이틀 화면 복귀
	public void ReturnTitle(){
		option.SetActive (false);
		rankingMenu.SetActive (false);
		quitGame.SetActive (false);
	}
}
