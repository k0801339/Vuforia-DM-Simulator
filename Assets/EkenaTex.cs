using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EkenaTex : MonoBehaviour, IVirtualButtonEventHandler{

	public Material m_VirtualButtonDefault;
    public Material m_VirtualButtonPressed;
    public float m_ButtonReleaseTimeDelay;

	// public GameObject model;

	public MeshRenderer model_Tex;

	VirtualButtonBehaviour[] virtualButtonBehaviours;

	// Use this for initialization
	void Start () {
		// Register with the virtual buttons TrackableBehaviour
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
			//Debug.Log("Get");
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

		if(vb.VirtualButtonName == "brown")
		{
			Material[] mats =  model_Tex.materials;
			mats[0] = Resources.Load("tex1", typeof(Material)) as Material;
			model_Tex.materials = mats;
			
		}
		else if(vb.VirtualButtonName == "black")
        {
			Material[] mats =  model_Tex.materials;
			mats[0] = Resources.Load("tex2", typeof(Material)) as Material;
			model_Tex.materials = mats;
			
		}
    }

	public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("OnButtonReleased: " + vb.VirtualButtonName);
    }

}
