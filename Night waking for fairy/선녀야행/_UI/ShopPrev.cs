using UnityEngine;
using System.Collections;

public class ShopPrev : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick(){
		Debug.Log ("111");
		Destroy (IntoShop.shop_menu);
	}
}
