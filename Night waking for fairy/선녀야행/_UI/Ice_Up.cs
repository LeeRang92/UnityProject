using UnityEngine;
using System.Collections;

public class Ice_Up : MonoBehaviour {

	void OnClick(){
		if (ValueManager.goldVal >= 500) {
			ValueManager.goldVal -= 500;
			ValueManager.ice += 10;
		}
	}
}
