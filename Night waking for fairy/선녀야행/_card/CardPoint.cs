using UnityEngine;
using System.Collections;

public class CardPoint : MonoBehaviour {

	public int fire=0;  //카드 포인트
	public int water=0;
	public int earth=0;

	public bool clickTarget = false;

	public static CardPoint instance;

	enum SkillType{
		FireEarth,
		FireIce,
		IceEarth,
		NonAttack,
	};
	
	void Start () {
		instance = this;
	}

	void Update () {
		Skills ();
	}

	void Skills(){
		if (playerJump.ReturnTop ()) {
			if(clickTarget){
			//스킬 종류
				if (fire == 1 && earth == 1) { 
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.FireEarth);
					fire = 0;
					earth = 0;
				} else if (fire == 1 && water == 1) {
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.FireIce);
					fire = 0;
					water = 0;
				} else if (water == 1 && earth == 1) {
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.IceEarth);
					earth = 0;
					water = 0;
				} else if (water == 2) {
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.NonAttack);
					water = 0;
				} else if (fire == 2) {
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.NonAttack);
					fire = 0;
				} else if (earth == 2) {
					skillSpawnPoint.instance.spwanSkill ((int)SkillType.NonAttack);
					earth = 0;
				}
				clickTarget = false;
			}
		}
	}
}
