using UnityEngine;
using System.Collections;

public class skillSpawnPoint : MonoBehaviour {

	public GameObject[] Skill; // 스킬 담을 배열
	public Transform skillSpawn; // 스킬 생성 위치

	public bool delCard = false; // 카드 삭제 체크
	bool attack = true;

	static public skillSpawnPoint instance;

	void Start(){
		instance = this;
	}

	public void spwanSkill(int skillIndex){
		Vector3 getY = transform.position;
		if (playerJump.ReturnTop()) {
			Instantiate (Skill[skillIndex], skillSpawn.position, skillSpawn.rotation); // 스킬 생성
			//MonsterAttack();
		}
	}

	void MonsterAttack(){ // 카드 1장 남았을 시 몬스터가 공격
		if (CardManager.instance.cardList.Count <= 1 ) {
			if (attack) {
				CreateMonBullet.shotBullet = true;
				//attack = false;
			}
		}
	}
}
