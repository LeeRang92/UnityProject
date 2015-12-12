using UnityEngine;
using System.Collections;

public class MicroPhone : MonoBehaviour {
	public float sensitivity = 100;
	public float loudness = 0;
	public AudioSource audio;

	void Update(){
		//녹음
		//Built-in Microphone : 내장마이크
		if (!audio.isPlaying) {
			audio.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
			audio.loop = true; // Set the AudioClip to loop
			audio.mute = true; // Mute the sound, we don't want the player to hear it
			while (!(Microphone.GetPosition("Built-in Microphone") > 0)){} // Wait until the recording has started
			audio.Play(); // Play the audio source!
		}
		loudness = GetAveragedVolume() * sensitivity;
		//점프
		if (loudness > 37f)
			playerMove.instance.Jump ();
	}
	//소리 크기
	float GetAveragedVolume(){ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);
		foreach(float s in data){
			a += Mathf.Abs(s);
		}
		return a/256;
	}
}