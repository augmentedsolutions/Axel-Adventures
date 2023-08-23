using UnityEngine;

public class switchScenes : MonoBehaviour
{

    void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void changeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
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
