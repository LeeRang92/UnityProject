using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHole_Obstacle : MonoBehaviour {

	public GameObject holeIn, holeOut;
	public List<GameObject> blackObj = new List<GameObject>();
	public static int count = 3;
	bool holeOn = false;
	
	void Update () {
		if (holeOn) {
			RotateBlackHole();
			if(count <= 0)
				DestroyBlackHole();
		}
	}

	void RotateBlackHole(){
		if (holeIn.transform.localScale.x <= 0.3f)
			holeIn.transform.localScale += new Vector3 (0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
		if (holeOut.transform.localScale.x <= 0.5f)
			holeOut.transform.localScale += new Vector3 (0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
		holeIn.transform.Rotate (new Vector3 (0, 0, 1));
		holeOut.transform.Rotate (new Vector3 (0, 0, -2));
	}

	void DestroyBlackHole(){
		holeIn.transform.localScale += new Vector3 (-0.1f, -0.1f, 0);
		holeOut.transform.localScale += new Vector3 (-0.1f, -0.1f, 0);
		if(holeOut.transform.localScale.x <= 0f)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			holeOn = true;
	}
}
