using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairFall : MonoBehaviour {
	private Animator animator;
	bool end = false;
	//private DetectShake shake;
	Quaternion origin; 
	
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		//shake = gameObject.GetComponent<DetectShake>();
		origin = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(end == false && animator.GetCurrentAnimatorStateInfo(0).IsName("END"))
		{
			Debug.Log("End the Animation");
			end = true;
		}

		if(end)
		{
			animator.enabled = false;
		}
		/*
		if(shake.isShake)
		{
			transform.rotation = origin;
		}
		*/
	}
}
