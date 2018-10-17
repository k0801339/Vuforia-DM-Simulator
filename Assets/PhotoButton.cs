using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoButton : MonoBehaviour {
    public GameObject AndyAndroidPrefab;
    public GameObject shopButton;
    public Image skeletonimg;
    private UnityEngine.UI.Image url_img;
    private TextMeshProUGUI url_txt;
    private WebClick web;
    public GameObject Cube;
    private TextMeshProUGUI txt;
    private Image img;
    private Text txt_ans;
    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        img = gameObject.GetComponent<Image>();
        txt_ans = gameObject.GetComponentInChildren<Text>();
        txt_ans.enabled = false;
        url_img = shopButton.GetComponent<UnityEngine.UI.Image>();
        //img.enabled = false;
        url_txt = shopButton.GetComponentInChildren<TextMeshProUGUI>();
        web = shopButton.GetComponent<WebClick>();
        skeletonimg.enabled = false;
        //skeletonimg.sprite = Resources.Load("chair/" + "0001", typeof(Sprite)) as Sprite;
        //skeletonimg.enabled = true;
        
        //txt.enabled = false;
        
        //FtpUploader uploader = new FtpUploader();
        //uploader.DownloadFile();
    }
	public void click() {
        //Debug.Log("Photot button pressed");

        captureScreenshot();
        StartCoroutine(captureScreenshot());
        Debug.Log("Click photo button");
        //Cube = OBJLoader.LoadOBJFile(Application.persistentDataPath + "Input.obj");
        //var andyObject = Instantiate(AndyAndroidPrefab, Vector3.zero, Quaternion.Euler(0, 90, 0));
        txt.enabled = false;
        img.enabled = false;
    }

    IEnumerator captureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        //string path = Application.persistentDataPath + "Screenshots" + Screen.width + "X" + Screen.height + "" + ".png";
        string path = Application.persistentDataPath + "/Input.png";

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height*2/3);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, Screen.height/3, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] imageBytes = screenImage.EncodeToPNG();

        //Save image to file
        System.IO.File.WriteAllBytes(path, imageBytes);

        FtpUploader uploader = new FtpUploader();
        uploader.UploadFile(imageBytes);
        
        txt.enabled = true;
        img.enabled = true;

        yield return new WaitForSeconds(15);

        string idx = uploader.DownloadFile();
        //url_img = shopButton.GetComponent<UnityEngine.UI.Image>();
        img.enabled = true;
        //url_txt = shopButton.GetComponentInChildren<TextMeshProUGUI>();
        txt.enabled = true;
        skeletonimg.enabled = true;
        skeletonimg.sprite = Resources.Load("chair/"+idx, typeof(Sprite)) as Sprite;
        Debug.Log("Show match"+idx);
        
    }
}



// IEnumerator TakeScreenshot()
// {

//     string imageName = "screenshot.png";

//     // Take the screenshot
//     ScreenCapture.CaptureScreenshot(imageName);

//     //Wait for 4 frames
//     // for (int i = 0; i < 5; i++)
//     // {
//     //     yield return null;
//     // }

//     // // Read the data from the file
//     // byte[] data = File.ReadAllBytes(Application.persistentDataPath + "/" + imageName);

//     // // Create the texture
//     // Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);

//     // // Load the image
//     // screenshotTexture.LoadImage(data);

//     // // Create a sprite
//     // Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

//     // // Set the sprite to the screenshotPreview
    // screenshotPreview.GetComponent<Image>().sprite = screenshotSprite;

// }
