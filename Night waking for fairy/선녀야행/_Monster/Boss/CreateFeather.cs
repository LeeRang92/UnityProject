using UnityEngine;
using System.Collections;

public class CreateFeather : MonoBehaviour {

	public Transform[] spawnPos;
	public GameObject[] feather;

	public static bool spawnFeather = false;

	float spawnTime = 1.8f;
	float getTime = 10f;
	int count = 0;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (spawnFeather) {
			if (playerJump.ReturnTop ()) {
				SpawnFeather();
			}
		}
	}

	void SpawnFeather()
	{
		GameObject ga;
		if (count <= 10) {
			getTime += Time.deltaTime;
			if (spawnTime < getTime) {
				count++;
			//중복 체크
				int i = Random.Range (0, 50);
				int j = Random.Range (0, spawnPos.Length);
				if (i <= 17)
					i = 1;
				else
					i = 0;					
				//깃털 생성
				ga = (GameObject)Instantiate (feather [i], spawnPos [j].position, Quaternion.identity);
				ga.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				getTime = 0;
			}
		}
	}
}
