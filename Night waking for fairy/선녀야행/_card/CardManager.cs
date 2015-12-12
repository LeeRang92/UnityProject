using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour {
	
	public GameObject[] card; // 카드 종류 저장
	public List<GameObject> cardList = new List<GameObject>(); // 생성된 카드 저장
	public GameObject gird; // card Object의 Parent

	//GUI 스크린 좌표로 변경
	public GameObject target;
	public Camera guiCam;
	Vector3 pos;

	public int getIndex_1; // 삭제된 배열의 index 받음
	public int getIndex_2;
	public Vector3 getCardPos_1; // 삭제된 배열의 위치값 받음
	public Vector3 getCardPos_2;
	public bool moveCard = false; // 몬스터 클릭 여부
	public bool bCardClick = true;

	float posX=0f; // x값 증가
	int arrayIndexNum=0;
	int currentCardPoint; // 카드 생성 지수
	float speed = 1f; //카드 이동 속도
	bool count = true;
	bool bullet = true;

	public static bool bBossPattern = true; // 보스 패턴 생성 여부
	public int clickCardNum = 0; // 카드 선택 개수
	
	static public CardManager instance;

	void Start () {
		instance = this;
		pos = guiCam.WorldToScreenPoint(target.transform.position); // gui 스크린 좌표로 변경
	}

	void FixedUpdate () {

		if (cardList.Count <= 0)
			bBossPattern = false;
		else if (cardList.Count > 0)
			bBossPattern = true;

		if (playerJump.ReturnTop()) {
			if(cardList.Count <= 1){
				if(bullet){
					CreateMonBullet.shotBullet = true;
					bullet = false;
				}
			}
		}

		else if (playerJump.ReturnIdle()) { // 정지 상태에서만 카드 생성
			if(playerController.start){
				CreateCard ();
				bullet = true;
			}
		}

		else if (playerJump.ReturnDown ()) { // player 낙하시 card 초기화
			for(int i=0; i<cardList.Count; i++)
				Destroy(cardList[i].gameObject);
			posX = 0f;
			cardList.Clear ();
			arrayIndexNum = 0;

		}

		if (cardList.Count <= 1)
			bCardClick = false;
		else if (cardList.Count > 1)
			bCardClick = true;
		if (cardList.Count > 1)
			MoveCard (); // 카드 나열
	}

	void CreateCard() // 카드 생성
	{
		if (Input.acceleration.x > 1) {
			currentCardPoint += 15;
		}
		if (Input.GetButtonDown ("Fire2")) {
			currentCardPoint += 15;
		}
		
		if (arrayIndexNum < 10 && currentCardPoint > 50) {
			int cardIndex = Random.Range (0, card.Length); // 카드 랜덤 생성
			cardList.Add((GameObject)Instantiate (card[cardIndex], new Vector3(posX, pos.y-0.22f, 0), Quaternion.identity));
			cardList[arrayIndexNum].transform.parent = gird.transform; // 자식 멤버로 만듬
			cardList[arrayIndexNum].transform.localScale = new Vector3(100f,100f,1f); // 카드 상대적 사이즈 조절

			posX += 0.3f; // X값 증가
			currentCardPoint = 0;
			if(arrayIndexNum < 10)
				arrayIndexNum += 1; //배열의 index값 증가
		}
	}

	void MoveCard(){
		float pos = 0f;
		if (moveCard) { // 몬스터를 클릭했을 시
			Destroy(cardList[CardManager.instance.getIndex_1].gameObject);
			Destroy(cardList[CardManager.instance.getIndex_2].gameObject);

			if (getIndex_1 < getIndex_2) {
				for (int i=1; i<cardList.Count; ++i) {
					if (getIndex_1 + i < cardList.Count && cardList [getIndex_1 + i] != null) {
						if (getCardPos_1.x + pos <= cardList [getIndex_1 + i].transform.position.x)
							cardList [getIndex_1 + i].transform.Translate (-speed * Time.deltaTime, 0, 0, Space.Self);
						pos += 0.3f;
						Invoke("ResetCardValue",0.6f);
					}
				}
			}
			else if (getIndex_1 > getIndex_2) { // 첫번째 카드 이동
				for (int i=1; i<cardList.Count; ++i) {
					if (getIndex_2 + i < cardList.Count && cardList [getIndex_2 + i] != null) {
						if (getCardPos_2.x + pos <= cardList [getIndex_2 + i].transform.position.x)
							cardList [getIndex_2 + i].transform.Translate (-speed * Time.deltaTime, 0, 0, Space.Self);
						pos += 0.3f;
						Invoke("ResetCardValue",0.6f);
					}
				}
			}
		}
	}

	void ResetCardValue(){
		if (moveCard) {
			if (getIndex_1 < getIndex_2) {
				cardList.RemoveAt (getIndex_2);
				cardList.RemoveAt (getIndex_1);
			}
			else if (getIndex_1 > getIndex_2) {
				cardList.RemoveAt (getIndex_1);
				cardList.RemoveAt (getIndex_2);
			}
			getIndex_1 = 0;
			getIndex_2 = 0;
			clickCardNum = 0;
			moveCard = false;
		}
	}
}


