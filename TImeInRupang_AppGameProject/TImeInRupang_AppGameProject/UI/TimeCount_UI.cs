using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCount_UI : MonoBehaviour {
	public Text text;
	public static float time;

	void Start () {
		time = 0f;
	}

	void Update () {
		time += Time.deltaTime;
		text.text = "Time : " + time.ToString ("0.0");
	}	
}
