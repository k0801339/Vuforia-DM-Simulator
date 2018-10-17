using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public int state;
	public string objname;
	public bool detectedplane;
	public bool readyToPut;
	public int texidx;
	// state 0: try to track the photo/object
	// state 1: already get the photo/object
	// state 2: ready to put them on the plane

	// Use this for initialization
	void Start () {
		
	}
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		state = 0;
		objname = "";
		detectedplane = false;
		readyToPut = false;
		texidx = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
