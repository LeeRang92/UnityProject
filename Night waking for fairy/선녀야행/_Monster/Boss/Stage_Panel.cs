using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage_Panel : MonoBehaviour {
	public GameObject gaPanel;
	public GameObject grid;
	public Transform[] spawnPanelPoints;
	
	public static List<GameObject> list_Panel = new List<GameObject>();
	public static int cardCheck = -1;
	public static bool spawnPanel = false; // 패널 생성

	List<int> saveRndNum = new List<int>();
	
	float posX = -0.4f;
	int count = 0;
	bool loop = true;
	int rndIndex = 0;

	bool checkPanel = false;

	float getTime = 0f;
	float spwanTime = 1f;
	
	void Update () {
		if(checkPanel){ // 카드 클릭 불가
			if (list_Panel.Count <= 0){
				CardManager.instance.bCardClick = true;
				checkPanel = false;
			}
		}

		if (spawnPanel) {
			SpawnPanel();
		}
	}

	void SpawnPanel(){
			if (count < 5) {
			checkPanel = true;
			CardManager.instance.bCardClick = false;

				getTime += Time.deltaTime;
				if (spwanTime < getTime) {
					loop = true;
					if (loop) {
						int i = Random.Range (0, spawnPanelPoints.Length);
						if (!saveRndNum.Contains (i)) {

							saveRndNum.Add (i);
							GameObject ga = (GameObject)Instantiate (gaPanel, spawnPanelPoints [i].position, spawnPanelPoints [i].rotation);
							ga.transform.localScale = new Vector3 (0.3f, 0.6f, 1f);
							ga.transform.parent = grid.transform;
							list_Panel.Add (ga);

							count ++;
							getTime = 0;
							loop = false;
						}
					}
				}
			}
		}

}
