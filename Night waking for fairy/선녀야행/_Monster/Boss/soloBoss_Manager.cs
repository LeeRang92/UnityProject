using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class soloBoss_Manager : MonoBehaviour {
	public GameObject targer_cross;
	public GameObject Cloud;
	public GameObject CountDown;
	public List<GameObject> saveCloud = new List<GameObject>();
	public bool bossState = false;
	GameObject saveCross;
    GameObject grid; // 부모 오브젝트
	GameObject ui;

	public int bossHealth = 50;
	int cloudNum = 5;
	float getTime = 0.5f;
	int createCloudCount = 0; // 구름 생성 갯수
	int spawnCloudNum = 5;
	bool countCnt = true;

	public static bool DestroyBoss = false;
	public static bool bCutDown = false;

	public static soloBoss_Manager instance;
	
	void Start () {
		instance = this;
		grid = GameObject.Find ("CloudGrid");
		ui = GameObject.Find ("UIPanel");
	}
	
	void Update () 
	{
		// 구름 생성시 카운트 다운 실행
		if (saveCloud.Count >= spawnCloudNum) {
			GameObject ga;
			if(countCnt){
				ga = (GameObject)Instantiate (CountDown, new Vector3 (0.4f, 1f, 0f), Quaternion.identity);
				ga.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
				ga.transform.parent = ui.transform;
				countCnt = false;
			}
		}

		// 구름 생성
		if (playerJump.ReturnTop ()) {
			if(CardManager.bBossPattern){
				getTime += Time.deltaTime;
				CreateCloud ();
			}
		}
		// 구름 초기화
		else if(playerJump.ReturnIdle()){
			createCloudCount = 0;
			countCnt = true;

		}
		else if(playerJump.ReturnJump())
			CreateMonBullet.cnt = true;

		// 카드 클릭 여부
		if (saveCloud.Count <= 0){
			CardManager.instance.bCardClick = true;
		}
	}

	void CreateCloud(){
		GameObject ga;

		if (createCloudCount < spawnCloudNum) {
			CardManager.instance.bCardClick = false; // 카드 클릭 불가
			if (getTime > 0.5f) {
				getTime = 0f;
				ga = (GameObject)Instantiate (Cloud, new Vector3 (Random.Range (-0f, 1f), Random.Range (0.1f, 1.5f), 0), Quaternion.identity);
				ga.transform.localScale = new Vector3 (1.5f, 1.5f, 1f);
				ga.transform.parent = grid.transform;
				saveCloud.Add (ga);
				createCloudCount++;
			}
		}
	}

	public IEnumerator OnMouseDown(){
		if (saveCloud.Count <= 0) {
			playerController.instance.AnimState = 0;
		
			saveCross = (GameObject)Instantiate (targer_cross, new Vector3 (this.gameObject.transform.position.x+0.1f, this.gameObject.transform.position.y+0.5f, 
		                                                                this.gameObject.transform.position.z - 0.5f), Quaternion.identity);
			saveCross.transform.localScale = new Vector3(0.5f,0.5f,1f);
			saveCross.transform.parent = this.gameObject.transform;
		
			CardManager.instance.moveCard = true;

			yield return new WaitForSeconds (1.1f);
			CardPoint.instance.clickTarget = true;
			yield return new WaitForSeconds (0.08f);
			Bullet.instance.target = (Transform)this.gameObject.transform; //선택 몬스터 값 넘겨줌
		}
	}

	void OnCollisionEnter (Collision other)
	{
		bossHealth -= 60;
		Destroy (saveCross);
		if (bossHealth <= 0) {
			DestroyBoss = true;
			playerJump.instance.unFreezCheck = true;
			Destroy (this.gameObject);
			//UIManager.uiOn = true;
		}
	}

}
