using UnityEngine;
using System.Collections;

public class Fast_Signspot : MonoBehaviour {

	GameObject playPos;
	
	void Start () {
		playPos = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			playPos.transform.Translate (new Vector3 (3f, 0.5f, 0));
	}
}
