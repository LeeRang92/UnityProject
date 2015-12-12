using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Volume_Slider : MonoBehaviour {
	public Slider slider;
	
	// Update is called once per frame
	void Update () {
		if (Audio_Control.volume_switch == true) {
			AudioListener.volume = slider.value;
		}
	}
}
