using UnityEngine;
using System.Collections;

public class GameStart_Label : MonoBehaviour {
	GameObject startLabel;
	// Use this for initialization
	IEnumerator Start () {
		startLabel = GameObject.Find ("GameStart_Label");
		yield return StartCoroutine("GameStart");
	}

	IEnumerator GameStart(){
		yield return new WaitForSeconds (3f);
		NGUITools.SetActive (startLabel, false);
		playerController.start = true;
		yield return new WaitForSeconds (0.3f);
		NGUITools.SetActive(Shake_Phone.shake,true);
		Destroy (this.gameObject);
	}
}
