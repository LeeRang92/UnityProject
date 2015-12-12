using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishScore_UI : MonoBehaviour {
	public Text text;

	void Update () {
		text.text = "" + TimeCount_UI.time.ToString("0.0");

	}
}
