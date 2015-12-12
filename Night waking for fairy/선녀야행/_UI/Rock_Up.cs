using UnityEngine;
using System.Collections;

public class Rock_Up : MonoBehaviour {

	void OnClick(){
		if (ValueManager.goldVal >= 500) {
			ValueManager.goldVal -= 500;
			ValueManager.earth += 10;
		}
	}
}
