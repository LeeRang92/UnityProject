using UnityEngine;
using System.Collections;

public class MonBulletSpawn : MonoBehaviour {
	
	public GameObject bullet; // Monster Attack Skill Object
	public Transform spawnPosition;

	public static MonBulletSpawn instance;

	public bool monBullet = false;

	void Start(){
		instance = this;
	}

	void Update(){
		if (monBullet) { // 카드 한장 1장 이하 남았을 시
			StartCoroutine("SpwanBullet");
		}
	}

	IEnumerator SpwanBullet(){
		yield return new WaitForSeconds (2f);
		Instantiate (bullet, spawnPosition.position, Quaternion.identity);
		//monBullet=false;
	}


}
