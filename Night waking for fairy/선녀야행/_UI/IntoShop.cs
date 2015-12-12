using UnityEngine;
using System.Collections;

public class IntoShop : MonoBehaviour {

	public GameObject shop;
	public GameObject ui;
	public static GameObject shop_menu;

	public static IntoShop instance;

	void Start () {
		instance = this;
	}
	void Update(){
		ui = GameObject.Find ("UIPanel");
	}

	void OnClick()
	{
		shop_menu = (GameObject)Instantiate (shop, new Vector3 (-0.18f, 1.7f, 0f), Quaternion.identity);
		shop_menu.transform.parent = ui.transform;
	}
}
