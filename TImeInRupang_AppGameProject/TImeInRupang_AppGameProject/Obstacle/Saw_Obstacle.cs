using UnityEngine;
using System.Collections;

public class Saw_Obstacle : MonoBehaviour {
	
	void Update () {
		transform.Rotate (new Vector3 (0, 0, -1));
	}
}
