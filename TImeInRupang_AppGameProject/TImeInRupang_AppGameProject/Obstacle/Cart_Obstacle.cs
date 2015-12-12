using UnityEngine;
using System.Collections;

public class Cart_Obstacle : MonoBehaviour {

	bool move = false;
	public GameObject wheel;
	Transform target;

	void Start(){
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		wheel.transform.Rotate (new Vector3 (0, 0, 2f));
		if (transform.position.x - 15f < target.transform.position.x) 
			move = true;
		if(move)
			transform.Translate (new Vector3 (-3f * Time.deltaTime, 0, 0));
	}
}
