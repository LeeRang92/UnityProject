using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	static public bool uiOn = false;

	void Update () {
		if (uiOn) {
			NGUITools.SetActive (PrevButton.menu, true);
			Time.timeScale = 0;
			uiOn = false;
		}
	
	}
}
