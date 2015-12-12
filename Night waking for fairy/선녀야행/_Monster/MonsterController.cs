using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour  {

	public GameObject uiMenu;
	public GameObject[] monster;     //일반 몬스터
	public Transform[] spawnPoints;  //스폰 위치  
	public List<GameObject> saveMonster = new List<GameObject>(); // 일반 몬스터 저장
	public List<GameObject> stageBoss = new List<GameObject> (); // 보스 저장
	public Transform[] bossPosition; // 보스 위치
	public GameObject saveBoss;
	public static GameObject stage_menu;
	GameObject ui;

	public int stageBossNum = 0; // 보스 소환
	public int bossSpawnCount = 0; // 보스 소환 카운터
	bool cnt = true; // 보스 중복 생성 방지
	int count=0; // 몬스터 생성 제한 카운터
	bool destroyCheck=false; // 정보 초기화 체크
	int monCount = 4; // 일반 몬스터 소환 

	public static int riseMonHealth = 0;


	static public MonsterController instance;

	void Strat(){
		instance = this;
	}

	void FixedUpdate()
	{
		// 몬스터 스폰
		if (bossSpawnCount < monCount) {
			if (playerJump.ReturnJump ()) {
				MonsterSpawn ();
			} 
			//남은 몬스터 삭제
			else if (playerJump.ReturnIdle ()) {
				cnt = true;
				if (destroyCheck)
					OnDestroy (); // 몬스터 리셋
			}
		} 
		// 점프시 보스 소환
		if (playerJump.ReturnJump ()) {
			if (bossSpawnCount >= monCount)  // 보스 스폰
				BossSpawn ();
		}	

		if (soloBoss_Manager.DestroyBoss) {
			ui = GameObject.Find ("UIPanel");
			CreateMenu();
		}
	}

	void MonsterSpawn ()
	{	
		if (count < spawnPoints.Length) {
			for(int spawnIndex = 0; spawnIndex < spawnPoints.Length; spawnIndex++){
				int monsterSpawnIndex = Random.Range (0, monster.Length);
				saveMonster.Add((GameObject)Instantiate (monster [monsterSpawnIndex], spawnPoints [spawnIndex].position, spawnPoints [spawnIndex].rotation));

				count++;
			}
		}
		destroyCheck = true;
	}
	
	void BossSpawn()
	{
		if (cnt) {
			saveBoss = (GameObject)Instantiate (stageBoss [stageBossNum], bossPosition[stageBossNum].position, bossPosition[stageBossNum].rotation);
			riseMonHealth += 10; // 몬스터 체력 상승
			stageBossNum++; // 다음 보스 소환
			cnt = false;
		}
	}

	void OnDestroy(){
		bossSpawnCount++; // 보스 소환 카운트

		for (int i=0; i<saveMonster.Count; i++)
			Destroy(saveMonster[i].gameObject);
		saveMonster.Clear();

		destroyCheck = false;
		count = 0;
	}

	void CreateMenu(){
		bossSpawnCount = 0;
		stage_menu = (GameObject)Instantiate (uiMenu, new Vector3 (-0.1f, 1.5f, 0f), Quaternion.identity);
		stage_menu.transform.parent = ui.transform;
		soloBoss_Manager.DestroyBoss = false;
	}
}
