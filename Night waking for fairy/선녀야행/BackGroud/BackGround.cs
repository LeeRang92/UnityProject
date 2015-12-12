using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackGround : MonoBehaviour {

	public GameObject bgCloud;
	float spawnTime = 10f;
	float getTime = 10f;
	GameObject ga;

	//구름 생성
	void Update () {
		getTime += Time.deltaTime;
		if (spawnTime < getTime) {
			getTime = 0f;
			ga = (GameObject)Instantiate (bgCloud, new Vector3 (3.5f, Random.Range(2f, 6f), 0), Quaternion.identity);
			ga.transform.localScale = new Vector3 (0.5f, 0.5f, -2f);

		}
	}
}
