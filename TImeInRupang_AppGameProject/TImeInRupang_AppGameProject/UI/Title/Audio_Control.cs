using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audio_Control : MonoBehaviour {
	public static bool volume_switch = true;

	public void Audio_On(){
		volume_switch = true;
	}

	public void Audio_Off(){
		volume_switch = false;
		AudioListener.volume = 0f;
	}
}
