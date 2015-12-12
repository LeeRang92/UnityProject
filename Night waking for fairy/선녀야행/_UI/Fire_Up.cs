using UnityEngine;
using System.Collections;

public class Fire_Up : MonoBehaviour {

	void OnClick(){
		if (ValueManager.goldVal >= 500) {
			ValueManager.goldVal -= 500;
			ValueManager.fire += 10;
		}
	}
}
