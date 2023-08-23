using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Auth : MonoBehaviour
{
    public GameObject errorText,ARCamera;
    public InputField inp;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("ShowAuth"))
        {
            PlayerPrefs.SetInt("ShowAuth", 1);

        }
        if(PlayerPrefs.GetInt("ShowAuth") == 0)
        {
            ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
            this.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onProceedClick()
    {
        if (inp.text == "ROAR")
        {
            this.gameObject.SetActive(false);
            ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
            PlayerPrefs.SetInt("ShowAuth", 0);

        }
        else
        {
            errorText.SetActive(true);
        }
    }
}
