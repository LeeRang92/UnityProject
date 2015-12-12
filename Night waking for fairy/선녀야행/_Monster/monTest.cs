using UnityEngine;
using System.Collections;

public class monTest : MonoBehaviour {
	public GameObject bullet; // Monster Attack Skill Object
	public Transform spawnPosition;
	public bool monBullet = false;
	
	public static monTest instance;
	
	void Start(){
		instance = this;
	}
	
	void Update(){
		if (monBullet == true) { // 카드 한장 1장 이하 남았을 시
			Invoke("spwanSkill", 2.0f);
			monBullet=false;
		}
	}
	
	void spwanSkill(){
		Instantiate (bullet, spawnPosition.position, Quaternion.identity);
		Debug.Log ("MonsterBullet22");
	}

}
