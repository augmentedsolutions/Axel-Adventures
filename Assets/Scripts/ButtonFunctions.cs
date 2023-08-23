using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ButtonFunctions : MonoBehaviour
{
    private Animation anim;
    private FixedJoystick joystick;
    public static GameObject ModelObj,videoPlayer;
    
    public bool isMoving = false, IsRuning = false;
    public float runSpeed, walkSpeed;
    public GameObject roarAudioPlayer, sleepAudioPlayer;
 
    void Awake()
    {
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }
  
    void Update()
    {
        if (joystick.Horizontal != 0f || joystick.Vertical != 0)
        {

            roarAudioPlayer.GetComponent<AudioSource>().Stop();
            sleepAudioPlayer.GetComponent<AudioSource>().Stop();
            isMoving = false;
            IsRuning = false;
            StopAllCoroutines();
            ModelObj.GetComponent<PlayerMovement>().enabled = true;
            videoPlayer.SetActive(false);
            ModelObj.SetActive(true);



        }
        if (isMoving)
        {
            ModelObj.transform.Translate(0, 0, Time.deltaTime * walkSpeed);
        }
        if (IsRuning)
        {
            ModelObj.transform.Translate(0, 0, Time.deltaTime * runSpeed);
        }
    }


    public void onSleepClick()
    {
        videoPlayer.SetActive(false);
        ModelObj.SetActive(true);


        sleepAudioPlayer.GetComponent<AudioSource>().Play();
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
       
        isMoving = false;
        IsRuning = false;
        ModelObj.GetComponent<PlayerMovement>().enabled = false;
        StopAllCoroutines();
        
        anim = ModelObj.GetComponent<Animation>();
        StartCoroutine(SleepAnimationSequence());
    }

    public void onWalkClick()
    {
        videoPlayer.SetActive(false);
        ModelObj.SetActive(true);
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
        sleepAudioPlayer.GetComponent<AudioSource>().Stop();
        isMoving = false;
        IsRuning = false;
        ModelObj.GetComponent<PlayerMovement>().enabled = false;
        StopAllCoroutines();
       
        anim = ModelObj.GetComponent<Animation>();
        StartCoroutine(WalkAnimationSequence());
    }

    public void onRunClick()
    {
        videoPlayer.SetActive(false);
        ModelObj.SetActive(true);
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
        sleepAudioPlayer.GetComponent<AudioSource>().Stop();
        isMoving = false;
        IsRuning = false;
        ModelObj.GetComponent<PlayerMovement>().enabled = false;
        StopAllCoroutines();
        
        anim = ModelObj.GetComponent<Animation>();
        StartCoroutine(RunAnimationSequence());
    }
    public void onTalkClick()
    {
        videoPlayer.SetActive(false);
        ModelObj.SetActive(true);
        isMoving = false;
        IsRuning = false;
        roarAudioPlayer.GetComponent<AudioSource>().Play();
        sleepAudioPlayer.GetComponent<AudioSource>().Stop();
        ModelObj.GetComponent<PlayerMovement>().enabled = false;
        StopAllCoroutines();
       
        anim = ModelObj.GetComponent<Animation>();
        StartCoroutine(TalkAnimationSequence());
    }

    public void onDanceClick()
    {
        videoPlayer.SetActive(false);
        ModelObj.SetActive(true);
        isMoving = false;
        IsRuning = false;
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
        sleepAudioPlayer.GetComponent<AudioSource>().Stop();
        ModelObj.GetComponent<PlayerMovement>().enabled = false;
        StopAllCoroutines();

        anim = ModelObj.GetComponent<Animation>();
        StartCoroutine(DanceAnimationSequence());
    }



    IEnumerator SleepAnimationSequence()
    {
        ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        ModelObj.transform.localPosition = new Vector3(10f, 0, 10f);
        anim.Play("Sleep");

        yield return new WaitForSeconds(4f);
        anim.Play("Idle");
        ModelObj.GetComponent<PlayerMovement>().enabled = true;
        
        
    }

    IEnumerator WalkAnimationSequence()
    {
        isMoving = true;
        for (int i = 0; i < 2; i++)
        {
            ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        ModelObj.transform.localPosition = new Vector3(40f, 0, 40f);
        anim.Play("Walk");
        
            yield return new WaitForSeconds(1.8f);

            ModelObj.transform.localEulerAngles = new Vector3(0, -90f, 0);

            yield return new WaitForSeconds(2f);

            ModelObj.transform.localEulerAngles = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(1.8f);

            ModelObj.transform.localEulerAngles = new Vector3(0, 90f, 0);

            yield return new WaitForSeconds(2f);
        }
        ModelObj.transform.localPosition = new Vector3(10f, 0, 10f);
        ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
         //anim.Play("Idle");
        ModelObj.GetComponent<PlayerMovement>().enabled = true;
        isMoving = false;
       
    }

    IEnumerator RunAnimationSequence()
    {

        IsRuning = true;
        for (int i = 0; i < 2; i++)
        {
            ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        ModelObj.transform.localPosition = new Vector3(40f, 0, 40f);
        anim.Play("Run");
       
            yield return new WaitForSeconds(1f);
        
        ModelObj.transform.localEulerAngles = new Vector3(0, -90f, 0);
         yield return new WaitForSeconds(1.2f);
        
        ModelObj.transform.localEulerAngles = new Vector3(0, 0, 0);
       
            yield return new WaitForSeconds(1f);
        
        ModelObj.transform.localEulerAngles = new Vector3(0, 90f, 0);
        yield return new WaitForSeconds(1.2f);
        }
        ModelObj.transform.localPosition = new Vector3(10f, 0, 10f);
        ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        //anim.Play("Idle");
        ModelObj.GetComponent<PlayerMovement>().enabled = true;
        IsRuning = false;
       
    }
    IEnumerator TalkAnimationSequence()
    {
        ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        ModelObj.transform.localPosition = new Vector3(10f, 0, 10f);
   
        anim.Play("Roar");
        yield return new WaitForSeconds(4f);
        anim.Play("Idle");
        ModelObj.GetComponent<PlayerMovement>().enabled = true;
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
    }

    IEnumerator DanceAnimationSequence()
    {
        ModelObj.transform.localEulerAngles = new Vector3(0, 180f, 0);
        ModelObj.transform.localPosition = new Vector3(10f, 0, 10f);

        anim.Play("Dance");
        yield return new WaitForSeconds(4f);
        anim.Play("Idle");
        ModelObj.GetComponent<PlayerMovement>().enabled = true;
        
    }

    public void onPlayClick()
    {
        roarAudioPlayer.GetComponent<AudioSource>().Stop();
        sleepAudioPlayer.GetComponent<AudioSource>().Stop();
        
        StopAllCoroutines();
        ModelObj.SetActive(false);
        videoPlayer.SetActive(true);
        videoPlayer.GetComponent<VideoPlayer>().Play();
    }

}
