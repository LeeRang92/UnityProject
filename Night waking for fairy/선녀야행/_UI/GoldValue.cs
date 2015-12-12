using UnityEngine;
using System.Collections;

public class GoldValue : MonoBehaviour {

	public UILabel _uilabel;

	
	void Start () {
		_uilabel = GetComponent<UILabel> ();
	}

	void Update () {
		_uilabel.text = ValueManager.goldVal.ToString ();
	}
}
