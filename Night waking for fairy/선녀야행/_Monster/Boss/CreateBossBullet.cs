using UnityEngine;
using System.Collections;

public class CreateBossBullet : MonoBehaviour {
	public GameObject bullet; // Monster Attack Skill Object
	public Transform spawnPosition;
	public static bool bossBullet = false;
	
	void Update(){
		if (bossBullet) { // 카드 한장 1장 이하 남았을 시
			Invoke("spwanSkill", 2.0f);
			bossBullet=false;
		}
	}
	
	void spwanSkill(){
		Instantiate (bullet, spawnPosition.position, Quaternion.identity);

	}
}
