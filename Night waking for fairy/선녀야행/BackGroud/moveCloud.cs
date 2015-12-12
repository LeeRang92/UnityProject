using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {

	float speed = 0.4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (-speed * Time.deltaTime, 0, 0);

		if (this.gameObject.transform.position.x <= -4.0f)
			Destroy (this.gameObject);
	}
}
