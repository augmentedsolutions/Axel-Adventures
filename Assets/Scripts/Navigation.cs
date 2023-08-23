using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Navigation : MonoBehaviour
{
    public GameObject howPanel,contactPanel,aboutPanel;

    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (howPanel.activeSelf)
            {
                back();
            }
            if (contactPanel.activeSelf)
            {
                back();
            }
            if (aboutPanel.activeSelf)
            {
                back();
            }
            else
            {
                changeScene("MainScene");
            }
        }
    }
    public void changeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void redirect(string url)
    {
        Application.OpenURL(url);
    }

    public void howTo(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void back()
    {
        howPanel.SetActive(false);
        contactPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("ShowAuth", 1);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            PlayerPrefs.SetInt("ShowAuth", 1);
        }
    }

}
