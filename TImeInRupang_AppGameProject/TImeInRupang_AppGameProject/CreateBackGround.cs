using UnityEngine;
using System.Collections;

public class CreateBackGround : MonoBehaviour {

	bool check = true;
	Transform playPos;

	void Start () {
		playPos = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	//배경 생성
	void Update(){
		if (transform.position.x < playPos.transform.position.x) {
			if(check){
				GroundManager.instance.CreateBackGround();
				check = false;
			}
		}
	}
}
