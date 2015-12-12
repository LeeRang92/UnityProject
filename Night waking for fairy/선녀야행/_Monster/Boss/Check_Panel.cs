using UnityEngine;
using System.Collections;

public class Check_Panel : MonoBehaviour {

	public TweenAlpha ta;

	bool click = true;
	
	void Start () {
		ta = GetComponent<TweenAlpha> ();
		ta.from = 0f;
		ta.to = 1f;
		ta.duration = 2f;
		ta.enabled = true;
	}

	void OnClick(){
		if (click) {
			ta.from = 1f;
			ta.to = 0.6f;
			ta.duration = 2f;
			ta.enabled = true;

			Stage2_Boss.deClick++;
			click = false;
			//Stage_Panel.cardCheck++;

			for (int i=0; i< Stage_Panel.list_Panel.Count; i++) {
				if (this.gameObject == Stage_Panel.list_Panel [i].gameObject) {
					if (i != Stage_Panel.cardCheck) {
						Stage2_Boss.checkPanel = true;
					}
				}
			}
		}
	}
}
