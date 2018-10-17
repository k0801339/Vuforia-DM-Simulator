using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureCtrl : MonoBehaviour {

	public int status = -1;
	public static float TouchTime = 0;

	protected bool isSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isSelected)
        {
            return;
        }
        else if(status == -1)
        {
            InputCheck();
        }

		if (Input.GetMouseButtonDown(0))
		{
			isSelected = true;
		}else if(Input.GetMouseButtonUp(0))
		{
			isSelected = false;
			status = -1;
			TouchTime = 0;
		}
	}
	protected void OnMouseDown() {
        isSelected = true;
    }

	protected void OnMouseUp() {
        isSelected = false;
        status = -1;
        TouchTime = 0;
    }
	protected virtual void InputCheck() { }

}
