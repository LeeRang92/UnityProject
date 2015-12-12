using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	
	float speed = 2.8f;
	int upSpeed = 20;
	
	void Update () {
		if (TimeCount_UI.time > upSpeed) {
			upSpeed += 20;
			speed += 0.3f;
		}
		//적 이동
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
	}

	//충돌
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			UIManager.instance.SetFinishMenu();
		}
	}
}
