using UnityEngine;
using System.Collections;

public class CreateGround : MonoBehaviour {

	bool check=true;
	Transform playPos;

	void Start(){
		playPos = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update(){
		if (transform.position.x < playPos.transform.position.x) {
			if(check){
				GroundManager.instance.CreateGround ();	
				check = false;
			}
		}
	}
}
