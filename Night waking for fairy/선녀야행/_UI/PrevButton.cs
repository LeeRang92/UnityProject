using UnityEngine;
using System.Collections;

public class PrevButton : MonoBehaviour {

	static public GameObject menu;
	public GameObject StageMenu;


	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("StageMenu");
		StageMenu = GameObject.Find ("StageMenu");
		Time.timeScale = 0;
		//NGUITools.SetActive (menu, false);

	}
	void Update(){
		Debug.Log (MonsterController.stage_menu);
	}

	void OnClick(){

		//NGUITools.SetActive (menu, false);
		Time.timeScale = 1;
		Destroy (MonsterController.stage_menu);
	}
}
