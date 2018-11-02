using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexChange : MonoBehaviour {
	public string objname;
	public bool getObj;
	public int texidx;
	private GameState gamestate;
	private Image img;
	// Use this for initialization
	void Start () {
		getObj = false;
		objname = "";
		img = gameObject.GetComponent<Image>();
	}
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GameObject arcamera = GameObject.Find("ARCamera");
        gamestate = arcamera.GetComponent<GameState>();
        if(gamestate != null)
        {
            Debug.Log("Get the state controller");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(getObj)
		{
			switch(objname)
			{
				case "ekenas":
					if(texidx == 1){
						img.sprite = Resources.Load("Wood", typeof(Sprite)) as Sprite;
					}
					else{
						img.sprite = Resources.Load("tweed02-l-color", typeof(Sprite)) as Sprite;
					}
					break;
				case "borje":
					if(texidx == 1){
						img.sprite = Resources.Load("fabric_pattern_tweed01-l-color", typeof(Sprite)) as Sprite;
					}
					else{
						img.sprite = Resources.Load("cloth_01-m-color", typeof(Sprite)) as Sprite;
					}
					break;
			}
		}
	}

	public void Click()
	{
		if(getObj)
		{
			Debug.Log("Change Texture");
			switch(objname)
			{
				case "ekenas":
					GameObject chair = GameObject.Find("Ekenas");
					MeshRenderer objMesh = chair.GetComponent<MeshRenderer>();
					Material[] mats =  objMesh.materials;
					if (texidx == 1){
						mats[0] = Resources.Load("tex1", typeof(Material)) as Material;
					}
					else{
						mats[0] = Resources.Load("m3", typeof(Material)) as Material;
					}
					objMesh.materials = mats;
					gamestate.texidx = texidx;

					break;
				case "borje":
					GameObject chair2 = GameObject.Find("Borje");
					MeshRenderer objMesh2 = chair2.GetComponent<MeshRenderer>();
					Material[] mats2 =  objMesh2.materials;
					if (texidx == 1){
						mats2[0] = Resources.Load("tex3", typeof(Material)) as Material;
					}
					else{
						mats2[0] = Resources.Load("tex4", typeof(Material)) as Material;
					}
					objMesh2.materials = mats2;
					gamestate.texidx = texidx;

					break;
				default:
					Debug.Log("Still not define. Please check TexChange.cs");
					break;
			}
		}
	}
}
