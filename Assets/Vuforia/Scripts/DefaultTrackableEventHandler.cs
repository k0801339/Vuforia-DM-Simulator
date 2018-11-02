/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using TMPro;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// 
/// Changes made to this file could be overwritten when upgrading the Vuforia version. 
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    //private WebClick shopButton;

    private GameObject shopButton;
    private WebClick web;
    private GameObject previewUI;
    private ShowPic picui;
    private GameObject texui1;
    private TexChange texctrl1;
    private GameObject texui2;
    private TexChange texctrl2;
    private GameState gamestate;
    

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        
        shopButton = GameObject.Find("ShopButton");
        web = shopButton.GetComponent<WebClick>();
        previewUI = GameObject.Find("Preview");
        picui = previewUI.GetComponent<ShowPic>();
        texui1 = GameObject.Find("Tex1");
        texui2 = GameObject.Find("Tex2");
        texctrl1 = texui1.GetComponent<TexChange>();
        texctrl2 = texui2.GetComponent<TexChange>();

        UnityEngine.UI.Image img = shopButton.GetComponent<UnityEngine.UI.Image>();
        img.enabled = false;
        TextMeshProUGUI txt = shopButton.GetComponentInChildren<TextMeshProUGUI>();
        //txt.enabled = false;

        img = previewUI.GetComponent<UnityEngine.UI.Image>();
        img.enabled = false;
        txt = previewUI.GetComponentInChildren<TextMeshProUGUI>();
        txt.enabled = false;

        img = texui1.GetComponent<UnityEngine.UI.Image>();
        img.enabled = false;
        img = texui2.GetComponent<UnityEngine.UI.Image>();
        img.enabled = false;
        
        //shopButton.SetActive(false);
    }
    protected virtual void Awake()
    {
        GameObject arcamera = GameObject.Find("ARCamera");
        gamestate = arcamera.GetComponent<GameState>();
        if(gamestate != null)
        {
            Debug.Log("Get the state controller");
        }
    }
    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            
            //shopButton.SetActive(true);
            //shopButton.SetActive(true);

            // Haven't tracked the photo/object
            if(gamestate != null && gamestate.state == 0 && (mTrackableBehaviour.TrackableName == "ekenas" || 
                mTrackableBehaviour.TrackableName == "borje"))
            {
                // important! Must set right state & objname
                gamestate.state = 1;
                gamestate.objname = mTrackableBehaviour.TrackableName;

                UnityEngine.UI.Image img = shopButton.GetComponent<UnityEngine.UI.Image>();
                img.enabled = true;
                TextMeshProUGUI txt;
                //txt.enabled = true;
                
                web.getObj = true;
                web.objname = mTrackableBehaviour.TrackableName;

                img = previewUI.GetComponent<UnityEngine.UI.Image>();
                img.enabled = true;
                txt = previewUI.GetComponentInChildren<TextMeshProUGUI>();
                txt.enabled = true;

                picui.getObj = true;
                picui.objname = mTrackableBehaviour.TrackableName;
                picui.chairname = "";

                img = texui1.GetComponent<UnityEngine.UI.Image>();
                img.enabled = true;
                img = texui2.GetComponent<UnityEngine.UI.Image>();
                img.enabled = true;

                texctrl1.getObj = true;
                texctrl1.objname = mTrackableBehaviour.TrackableName;
                texctrl2.getObj = true;
                texctrl2.objname = mTrackableBehaviour.TrackableName;

                OnTrackingFound();
                GameObject detectedChair = GameObject.FindGameObjectWithTag(mTrackableBehaviour.TrackableName);
                Animator animator = detectedChair.GetComponent<Animator>();
                animator.SetTrigger("start");
            }
            else if(gamestate != null && gamestate.state == 2 && mTrackableBehaviour.TrackableName != "ekenas" && 
                mTrackableBehaviour.TrackableName != "borje")
            {
                gamestate.detectedplane = true;
                // put the correspoding obj on the plane
                Debug.Log("Detect the plane -> wait to click button");
                GameObject arrangeButton = GameObject.Find("Arrangement");
                gamestate.state = 3;

                // ArrangeButton bb = arrangeButton.GetComponent<ArrangeButton>();
                // bb.Click();
                
            }
            else if(gamestate != null && gamestate.state == 1)
            {   
                // Always not enter in
                Debug.Log("state 1");
                
            }
            else if(gamestate != null && gamestate.state == 3)
            {
                Debug.Log("Press arrange button now");
            }
            else // TODO: create at here
            {
                Debug.Log("Maybe found plane. Do nothing.");
                //OnTrackingFound();
            }
            /*
            UnityEngine.UI.Image img = shopButton.GetComponent<UnityEngine.UI.Image>();
            img.enabled = true;
            TextMeshProUGUI txt = shopButton.GetComponentInChildren<TextMeshProUGUI>();
            txt.enabled = true;
            
            web.getObj = true;
            web.objname = mTrackableBehaviour.TrackableName;

            img = previewUI.GetComponent<UnityEngine.UI.Image>();
            img.enabled = true;
            txt = previewUI.GetComponentInChildren<TextMeshProUGUI>();
            txt.enabled = true;

            picui.getObj = true;
            picui.objname = mTrackableBehaviour.TrackableName;

            img = texui1.GetComponent<UnityEngine.UI.Image>();
            img.enabled = true;
            img = texui2.GetComponent<UnityEngine.UI.Image>();
            img.enabled = true;

            texctrl1.getObj = true;
            texctrl1.objname = mTrackableBehaviour.TrackableName;
            texctrl2.getObj = true;
            texctrl2.objname = mTrackableBehaviour.TrackableName;
            
            
            // show chair animation
            GameObject detectedChair = GameObject.FindGameObjectWithTag(mTrackableBehaviour.TrackableName);
            Animator animator = detectedChair.GetComponent<Animator>();
            animator.SetTrigger("start");
            */
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            gamestate.detectedplane = false;
            if(gamestate.state == 1)
            {
                gamestate.state = 0;

                UnityEngine.UI.Image img = shopButton.GetComponent<UnityEngine.UI.Image>();
                img.enabled = false;
                TextMeshProUGUI txt;
               // txt.enabled = false;

                web.getObj = false;
                web.objname = mTrackableBehaviour.TrackableName;

                img = previewUI.GetComponent<UnityEngine.UI.Image>();
                img.enabled = false;
                txt = previewUI.GetComponentInChildren<TextMeshProUGUI>();
                txt.enabled = false;

                picui.getObj = false;

                img = texui1.GetComponent<UnityEngine.UI.Image>();
                img.enabled = false;
                img = texui2.GetComponent<UnityEngine.UI.Image>();
                img.enabled = false;

                texctrl1.getObj = false;
                //texctrl1.objname = mTrackableBehaviour.TrackableName;
                texctrl2.getObj = false;
                //texctrl2.objname = mTrackableBehaviour.TrackableName;

                OnTrackingLost();
            }
            /*
            else if(gamestate.state == 2)
            {
                GameObject planeobj;
                switch(gamestate.objname){
                    case "ekenas":
                        planeobj = GameObject.Find("ekenas_plane");
                        var rendererComponents = planeobj.GetComponentsInChildren<Renderer>(true);
                        var colliderComponents = planeobj.GetComponentsInChildren<Collider>(true);
                        var canvasComponents = planeobj.GetComponentsInChildren<Canvas>(true);

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

                }
            }
            */
            else{
                OnTrackingLost();
            }
            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            
            //GameObject detectedChair = GameObject.FindGameObjectWithTag(mTrackableBehaviour.TrackableName);
            //Animator animator = detectedChair.GetComponent<Animator>();
            //animator.SetTrigger("return");
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS
}
