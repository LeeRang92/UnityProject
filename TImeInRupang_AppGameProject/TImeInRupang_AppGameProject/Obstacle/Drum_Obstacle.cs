using UnityEngine;
using System.Collections;

public class Drum_Obstacle : MonoBehaviour {

	int count = 0;
	public AudioClip effectSound;
	AudioSource audio;

	void Awake(){
		audio = GetComponent<AudioSource> ();
	}

	void OnMouseDown(){
		count++;
		audio.PlayOneShot (effectSound);
		if (count >= 5)
			Destroy (this.gameObject);
	}
}
