using UnityEngine;
using System.Collections;

public class Soldier_Obstacle : MonoBehaviour {
	public static bool move = false;
	Transform target;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update(){
		if (transform.position.x - 15f < target.transform.position.x) 
			move = true;
		if(move)
		transform.Translate (new Vector3 (-3f * Time.deltaTime, 0, 0));
	}
}
