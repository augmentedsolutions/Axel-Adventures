using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatSuite.Sharing;
using UnityEngine.UI;
using System.IO;
public class Capture : MonoBehaviour
{
   // private Component[] UItoHide;
    private Texture2D ss;
    public GameObject imgPreview;
    public RawImage irawImage;
   // public GameObject mainUI;
    public void captureScreenShot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }
    private IEnumerator TakeScreenshotAndSave()
    {
        GetComponent<AudioSource>().Play();
       // UItoHide = mainUI.GetComponentsInChildren<Image>();
        //foreach (Image hide in UItoHide)
          //  hide.enabled = false;
        //recoText.SetActive(false);
        yield return new WaitForEndOfFrame();

        ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "Photo.jpeg");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());
        // To avoid memory leaks
        imgPreview.SetActive(true);
        irawImage.texture = ss;

    }
    public void ShareImg()
    {
        var payload = new SharePayload();
        payload.AddImage(ss);

        payload.Commit();
        discardImg();
    }
    public void saveImg()
    {
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "AR", "Photo {0}.jpeg"));
        discardImg();
    }
    public void discardImg()
    {
        imgPreview.SetActive(false);
       // foreach (Image hide in UItoHide)
         //   hide.enabled = true;
        //recoText.SetActive(true);
    }
}
