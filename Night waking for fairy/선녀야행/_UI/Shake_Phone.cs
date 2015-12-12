using UnityEngine;
using System.Collections;

public class Shake_Phone : MonoBehaviour {

	public static GameObject shake;
	public TweenAlpha ta;
	// Use this for initialization
	void Start () {
		shake = GameObject.Find ("Shake_Phone");
		ta = GetComponent<TweenAlpha> ();
		ta.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerController.start) {
			if (playerJump.ReturnIdle ()) {
				NGUITools.SetActive (shake, true);
				ta.from = 0f;
				ta.to = 1f;
				ta.duration = 0.7f;
				ta.enabled = true;
			}
			if (playerJump.ReturnJump ()) {
				ta.from = 1f;
				ta.to = 0f;
				ta.duration = 1f;
				ta.enabled = true;
				NGUITools.SetActive (shake, false);
			}
		}
	}
}
