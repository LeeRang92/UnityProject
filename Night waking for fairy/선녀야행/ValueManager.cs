using UnityEngine;
using System.Collections;

public class ValueManager : MonoBehaviour {

	public static int fire = 0;
	public static int earth = 0;
	public static int ice = 0;
	public static float goldVal = 0;


	void SaveValue(){
		PlayerPrefs.SetInt ("FIRE", fire);
		PlayerPrefs.SetInt ("EARTH", earth);
		PlayerPrefs.SetInt ("ICE", ice);
		PlayerPrefs.SetFloat ("GOLD", goldVal);
	}

	void loadValue(){
		fire = PlayerPrefs.GetInt ("FIRE");
		earth = PlayerPrefs.GetInt ("EARTH");
		ice = PlayerPrefs.GetInt ("ICE");
		goldVal = PlayerPrefs.GetFloat ("GOLD");
	}
}
