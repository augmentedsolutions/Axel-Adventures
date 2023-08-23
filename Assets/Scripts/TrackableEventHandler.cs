using UnityEngine;
using UnityEngine.Video;
using Vuforia;
public class TrackableEventHandler : DefaultTrackableEventHandler
{

    public GameObject model,videoPlayer;
    public GameObject roarAudioPlayer, sleepAudioPlayer;
    public GameObject joystick,canvas;

    public void onFound()
    {
        
            
            ButtonFunctions.ModelObj = model;
            ButtonFunctions.videoPlayer = videoPlayer;

            joystick.SetActive(true);
            canvas.SetActive(true);

            this.GetComponent<AudioSource>().Play();
        
    }

   public void onLost()
    {
       
           
            joystick.SetActive(false);
            canvas.SetActive(false);

            model.SetActive(true);
            videoPlayer.SetActive(false);
            videoPlayer.GetComponent<VideoPlayer>().Stop();
            roarAudioPlayer.GetComponent<AudioSource>().Stop();
            sleepAudioPlayer.GetComponent<AudioSource>().Stop();

        
    }

   
   
}
