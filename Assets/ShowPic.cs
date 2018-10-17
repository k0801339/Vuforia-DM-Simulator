using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPic : MonoBehaviour {
	public string chairname;
	public string objname;
	private TextMeshProUGUI txt;
	private Image img;
	public bool getObj;
	// Use this for initialization
	void Start () {
		getObj = false;
		chairname = "";
		objname = "";
		txt = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		img = gameObject.GetComponent<Image>();
		img.enabled = false;
		txt.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(getObj && chairname.Equals(""))
		{
			Debug.Log("Start Show Preview");
			switch(objname)
			{
				case "ekenas":
					chairname = "ekenas";
					img.sprite = Resources.Load("ekenas", typeof(Sprite)) as Sprite;
					txt.SetText(chairname);
					break;
				case "borje":
					chairname = "borje";
					img.sprite = Resources.Load("borje", typeof(Sprite)) as Sprite;
					txt.SetText(chairname);
					break;
			}
		}
		
	}
}
