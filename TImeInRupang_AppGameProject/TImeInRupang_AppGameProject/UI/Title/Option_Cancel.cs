using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option_Cancel : MonoBehaviour {

	public Image image;
	public GameObject On, Off;
	bool click = true;

	void Start(){
		Off.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.Escape)) {
			image.gameObject.SetActive(false);
		}

		if(Application.platform == RuntimePlatform.Android){
			if(Input.GetKey(KeyCode.Escape)){
				MenuExit();
			}
		}
	}

	public void VolumeOnOff(){
		if (click) {
			On.SetActive (false);
			Off.SetActive (true);
			click = false;
		} else if (!click) {
			Off.SetActive (false);
			On.SetActive (true);
			click = true;
		}
	}

	public void MenuExit(){
		gameObject.SetActive (false);
	}
}
