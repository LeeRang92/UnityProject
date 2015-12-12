using UnityEngine;
using System.Collections;


public class FireCard : MonoBehaviour {

	bool clickCheck = true;
	public TweenAlpha ta;
	
	void Start(){
		ta = GetComponent<TweenAlpha> ();
	}
	
	
	void OnClick()
	{
		
		if (playerJump.ReturnTop ()) {
			if (CardManager.instance.bCardClick){
				if (CardManager.instance.clickCardNum < 2) {
					if (clickCheck) {
						clickCheck = false;
				
						ta.from = 1f;
						ta.to = 0.6f;
						ta.duration = 2f;
						ta.enabled = true;

						for (int index=0; index<CardManager.instance.cardList.Count; index++) { // 카드 정보 cardManager에게 넘김
							if (this.gameObject == CardManager.instance.cardList [index]) {
						
								if (CardManager.instance.clickCardNum == 0) {	
									CardManager.instance.getIndex_1 = index; // 배열의 index 번호 넘겨줌
									CardManager.instance.getCardPos_1 = CardManager.instance.cardList [index].transform.position; //현재 오브젝트의 position값 넘김
						
								} else if (CardManager.instance.clickCardNum >= 1) {
									CardManager.instance.getIndex_2 = index; // 배열의 index 번호 넘겨줌
									CardManager.instance.getCardPos_2 = CardManager.instance.cardList [index].transform.position; //현재 오브젝트의 position값 넘김
								}

								CardManager.instance.clickCardNum++;
							}
					
						}
		
						if (CardPoint.instance.fire <= 2)  // 중복 카드 2개까지만
							CardPoint.instance.fire += 1;
					}
				}
			}
		}
	}
}
