using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class RotateCtrl : MonoBehaviour {

	private Touch oldTouch1;  //上次触摸点1(手指1)  
    private Touch oldTouch2;  //上次触摸点2(手指2) 
    private GameObject shopButton;
    private WebClick web;
    public DetectShake shake;

	public MeshRenderer objMesh;
    Quaternion origin;
    Vector3 origin_euler;

	// Use this for initialization
	void Start () {
		shopButton = GameObject.Find("ShopButton");
        web = shopButton.GetComponent<WebClick>();
        origin = transform.rotation;
        //shake = gameObject.GetComponent<DetectShake>();
        origin_euler = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1 && web.getObj)
		{
			Debug.Log("Do Rotate");
			// For test
			//Material[] mats =  objMesh.materials;
			//mats[0] = Resources.Load("tex2", typeof(Material)) as Material;
			//objMesh.materials = mats;

			Touch touch = Input.GetTouch(0);
			Vector2 deltaPos = touch.deltaPosition;
            Vector3 vv3 = new Vector3(0, 0, 11f);
			//transform.RotateAround(vv3, Vector3.down, deltaPos.x * 0.1f);
            //transform.RotateAround(vv3, Vector3.right, deltaPos.y * 0.1f);

			transform.Rotate(Vector3.back * deltaPos.x * 0.1f, Space.World);
			transform.Rotate(Vector3.right * deltaPos.y * 0.1f, Space.World);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0.0f);
		}
		else if(Input.touchCount <= 0)
		{
			//Debug.Log("No Rotate");
			//Material[] mats =  objMesh.materials;
			//mats[0] = Resources.Load("m3", typeof(Material)) as Material;
			//objMesh.materials = mats;
		}
        if(shake.isShake)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        
        if(web.getObj)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.World);
            }
    
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Rotate(Vector3.up, -45 * Time.deltaTime, Space.World);
            }
    
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(Vector3.left, 45 * Time.deltaTime, Space.World);
            }
    
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Rotate(Vector3.left, -45 * Time.deltaTime, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("Euler restore");
                //transform.eulerAngles = origin_euler;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            
        }
        
	}

	/*
	protected override void InputCheck()
    {
        #region  单点触发旋转（真实模型旋转）
        if (Input.touchCount == 1)
        {
            //触摸为移动类型
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                status = 1;
                
            	StartCoroutine(CustomOnMouseDown());
                
                
            }
            
        }
        #endregion
 
        #region   键盘A、D、W、S模拟旋转（真实模型旋转）
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.World);
        }
 
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -45 * Time.deltaTime, Space.World);
        }
 
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.left, 45 * Time.deltaTime, Space.World);
        }
 
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(Vector3.left, -45 * Time.deltaTime, Space.World);
        }
        #endregion
    }
 
    IEnumerator CustomOnMouseDown()
    {
        //当检测到一直触碰时，会不断循环运行
        while (Input.GetMouseButton(0))
        {
            //判断是否点击在UI上
#if UNITY_ANDROID || UNITY_IPHONE
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
			    if (EventSystem.current.IsPointerOverGameObject())
#endif
            {
                Debug.Log("当前点击在UI上");
            }
            else
            {
                float XX = Input.GetAxis("Mouse X");
                float YY = Input.GetAxis("Mouse Y");
                #region
                //判断左右滑动的距离与上下滑动距离大小
                if (Mathf.Abs(XX) >= Mathf.Abs(YY))
                {
                    //单指向左滑动情况
                    if (XX < 0)
                    {
                        transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.World);
                    }
                    //单指向右滑动情况
                    if (XX > 0)
                    {
                        transform.Rotate(-Vector3.up, 45 * Time.deltaTime, Space.World);
                    }
                }
                else
                {
                    //单指向下滑动情况
                    if (YY < 0)
                    {
                        transform.Rotate(Vector3.left, 45 * Time.deltaTime, Space.World);
                    }
                    //单指向上滑动情况
                    if (YY > 0)
                    {
                        transform.Rotate(-Vector3.left, 45 * Time.deltaTime, Space.World);
                    }
                }
                #endregion
            }
            yield return new WaitForFixedUpdate();
        }
    }
	*/

}
