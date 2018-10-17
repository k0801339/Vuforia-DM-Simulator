using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebClick : MonoBehaviour {

	// Use this for initialization

	public string objname;
	public bool getObj;

	private string url;
	void Start () {
		getObj = false;
		url = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(getObj && url.Equals(""))
		{
			switch(objname)
			{
				case "ekenas":
					Debug.Log("Ekena site set up");
					url = "https://www.ikea.com/tw/zh/catalog/products/30276653/";
					break;
				case "skeleton":
					Debug.Log("Skeleton match mode");
					url = "https://www.ikea.com/us/en/catalog/categories/departments/living_room/16239/";
					break;
				case "borje":
					Debug.Log("Borje site set up");
					url = "https://www.ikea.com/tw/zh/catalog/products/40410793/";
					break;
			}
		}
	}

	public void Click()
	{
		if(getObj)
		{
			Debug.Log("Open Website");
			Application.OpenURL(url);
		}
	}
}
