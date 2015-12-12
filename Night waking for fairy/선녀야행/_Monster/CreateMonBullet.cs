using UnityEngine;
using System.Collections;

public class CreateMonBullet : MonoBehaviour {
	public GameObject bullet; // Monster Attack Skill Object
	public Transform spawnPosition;
	public static bool shotBullet = false;
	public static bool cnt;
	
	public static CreateMonBullet instance;
	
	void Start(){
		instance = this;
		cnt = true;
	}
	
	void Update(){
		if (shotBullet) { // 카드 한장 1장 이하 남았을 시
			StartCoroutine("spwanSkill");
		}
		if (playerJump.ReturnDown ())
			shotBullet = false;
	}
	
	IEnumerator spwanSkill(){
		yield return new WaitForSeconds (2f);
		if (cnt) {
			Instantiate (bullet, spawnPosition.position, Quaternion.identity);
			yield return new WaitForSeconds (0.01f);
			cnt = false;
		}
	}
}
