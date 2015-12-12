using UnityEngine;
using System.Collections;

public class Robot_Obstacle : MonoBehaviour {

	public Rigidbody2D[] robots;
	public AudioClip effectSound;
	AudioSource audio;

	int clickCnt = 0;

	void Awake(){
		audio = GetComponent<AudioSource> ();
	}

	void OnMouseDown(){
		clickCnt++;
		audio.PlayOneShot (effectSound);
		if (clickCnt >= 5) {
			GetComponent<Collider> ().isTrigger = true;
			for(int i=0; i < 8; i++)
				robots [i].isKinematic = false;
		}
	}
}
