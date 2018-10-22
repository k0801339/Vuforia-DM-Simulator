using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrangeButton : MonoBehaviour {
	public GameState gamestate;
	private Image img;
    //private TextMeshProUGUI txt;
	// Use this for initialization
	void Start () {
		//txt = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        img = gameObject.GetComponent<Image>();
		//txt.enabled = false;
		img.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(gamestate.state == 1)
		{
			//txt.enabled = true;
			img.enabled = true;
		}
		else if(gamestate.state == 0)
		{
			//txt.enabled = false;
			img.enabled = false;
		}
	}

	public void Click()
	{
		if(gamestate.state == 1)
		{
			Debug.Log("Turn to arrangement state");
			gamestate.state = 2;
			switch(gamestate.objname){
				case "ekenas":
					GameObject obj = GameObject.Find("ImageTarget1");
					var rendererComponents = obj.GetComponentsInChildren<Renderer>(true);
					var colliderComponents = obj.GetComponentsInChildren<Collider>(true);
					var canvasComponents = obj.GetComponentsInChildren<Canvas>(true);

					// Disable rendering:
					foreach (var component in rendererComponents)
						component.enabled = false;

					// Disable colliders:
					foreach (var component in colliderComponents)
						component.enabled = false;

					// Disable canvas':
					foreach (var component in canvasComponents)
						component.enabled = false;
					
					break;
				case "borje":
					GameObject obj2 = GameObject.Find("ImageTarget2");
					var rendererComponents2 = obj2.GetComponentsInChildren<Renderer>(true);
					var colliderComponents2 = obj2.GetComponentsInChildren<Collider>(true);
					var canvasComponents2 = obj2.GetComponentsInChildren<Canvas>(true);

					// Disable rendering:
					foreach (var component in rendererComponents2)
						component.enabled = false;

					// Disable colliders:
					foreach (var component in colliderComponents2)
						component.enabled = false;

					// Disable canvas':
					foreach (var component in canvasComponents2)
						component.enabled = false;
					
					break;
			}
		}
		else if(gamestate.state == 2 && gamestate.detectedplane)
		{
			gamestate.readyToPut = true;
			GameObject planeobj;
			Debug.Log("Put the chair");
            switch(gamestate.objname){
                case "ekenas":
                    planeobj = GameObject.Find("ekenas_plane");
                    var rendererComponents = planeobj.GetComponentsInChildren<Renderer>(true);
                    var colliderComponents = planeobj.GetComponentsInChildren<Collider>(true);
                    var canvasComponents = planeobj.GetComponentsInChildren<Canvas>(true);

                    // Disable rendering:
                    foreach (var component in rendererComponents)
                        component.enabled = true;

                    // Disable colliders:
                    foreach (var component in colliderComponents)
                        component.enabled = true;

                    // Disable canvas':
                    foreach (var component in canvasComponents)
                        component.enabled = true;
					MeshRenderer objMesh = planeobj.GetComponentInChildren<MeshRenderer>();
					Material[] mats =  objMesh.materials;
					if (gamestate.texidx == 1){
						mats[0] = Resources.Load("tex1", typeof(Material)) as Material;
					}
					else{
						mats[0] = Resources.Load("m3", typeof(Material)) as Material;
					}
					objMesh.materials = mats;
					
                    break;
				case "borje":
					planeobj = GameObject.Find("borje_plane");
					var rendererComponents2 = planeobj.GetComponentsInChildren<Renderer>(true);
                    var colliderComponents2 = planeobj.GetComponentsInChildren<Collider>(true);
                    var canvasComponents2 = planeobj.GetComponentsInChildren<Canvas>(true);

                    // Disable rendering:
                    foreach (var component in rendererComponents2)
                        component.enabled = true;

                    // Disable colliders:
                    foreach (var component in colliderComponents2)
                        component.enabled = true;

                    // Disable canvas':
                    foreach (var component in canvasComponents2)
                        component.enabled = true;
					MeshRenderer objMesh2 = planeobj.GetComponentInChildren<MeshRenderer>();
					Material[] mats2 =  objMesh2.materials;
					if (gamestate.texidx == 1){
						mats2[0] = Resources.Load("tex3", typeof(Material)) as Material;
					}
					else{
						mats2[0] = Resources.Load("tex4", typeof(Material)) as Material;
					}
					objMesh2.materials = mats2;

					break;

            }
		}
		else if(gamestate.state == 2 && !gamestate.detectedplane)
		{
			gamestate.state = 1;
			switch(gamestate.objname){
				case "ekenas":
					GameObject obj = GameObject.Find("ImageTarget1");
					var rendererComponents = obj.GetComponentsInChildren<Renderer>(true);
					var colliderComponents = obj.GetComponentsInChildren<Collider>(true);
					var canvasComponents = obj.GetComponentsInChildren<Canvas>(true);

					// Disable rendering:
					foreach (var component in rendererComponents)
						component.enabled = true;

					// Disable colliders:
					foreach (var component in colliderComponents)
						component.enabled = true;

					// Disable canvas':
					foreach (var component in canvasComponents)
						component.enabled = true;
					
					break;
				case "borje":
					GameObject obj2 = GameObject.Find("ImageTarget2");
					var rendererComponents2 = obj2.GetComponentsInChildren<Renderer>(true);
					var colliderComponents2 = obj2.GetComponentsInChildren<Collider>(true);
					var canvasComponents2 = obj2.GetComponentsInChildren<Canvas>(true);

					// Disable rendering:
					foreach (var component in rendererComponents2)
						component.enabled = true;

					// Disable colliders:
					foreach (var component in colliderComponents2)
						component.enabled = true;

					// Disable canvas':
					foreach (var component in canvasComponents2)
						component.enabled = true;
					
					break;
			}
		}
		
	}
}
