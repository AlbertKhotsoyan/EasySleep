using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// using UnityEngine.Advertisements;

public class Menu : MonoBehaviour
{
    public enum AudioChannel { Audio1, Audio2, Audio3, Audio4, Audio5, Audio6};
    public float Audio1VolumePercent { get; private set; }
    public float Audio2VolumePercent { get; private set; }
    public float Audio3VolumePercent { get; private set; }
    public float Audio4VolumePercent { get; private set; }
    public float Audio5VolumePercent { get; private set; }
    public float Audio6VolumePercent { get; private set; }
    public AudioSource[] musicSources;
    public Slider[] volumeSliders;
    public GameObject[] Stop;
    public GameObject[] music;
    public GameObject[] Slider;
    public GameObject[] Text;
    public GameObject mainMenuHolder;
    public GameObject timerMenuHolder;
//    public GameObject NotificationHolder;
    public GameObject SetTimer;
    public GameObject InTimer;
    public Text TimerText;
    public float time;
    public bool finnished = false;
    public bool ignoreListenerPause;
    public static int sleepTimeout;

    void Start()
    {   
        Application.runInBackground = true;
        ignoreListenerPause = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
 //       NotificationHolder.SetActive(true);
        mainMenuHolder.SetActive(false);
        timerMenuHolder.SetActive(false);
        mainMenuHolder.SetActive(true);
        InTimer.SetActive(false);
        volumeSliders[0].value = Audio1VolumePercent;
        volumeSliders[1].value = Audio2VolumePercent;
        volumeSliders[2].value = Audio3VolumePercent;
        volumeSliders[3].value = Audio4VolumePercent;
        volumeSliders[4].value = Audio5VolumePercent;
        volumeSliders[5].value = Audio6VolumePercent;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText.text = time.ToString("f0") ;
        }

        if (time < 0)
        {
            Application.Quit();
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();

                return;
            }
        }

        if (Application.platform == RuntimePlatform.TizenPlayer)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();

                return;
            }
        }
    }

    void Awake()
    {
            Application.runInBackground = true;
            Audio1VolumePercent = PlayerPrefs.GetFloat("Audio1", 1);
            Audio2VolumePercent = PlayerPrefs.GetFloat("Audio2", 1);
            Audio3VolumePercent = PlayerPrefs.GetFloat("Audio3", 1);
            Audio4VolumePercent = PlayerPrefs.GetFloat("Audio4", 1);
            Audio5VolumePercent = PlayerPrefs.GetFloat("Audio5", 1);
            Audio6VolumePercent = PlayerPrefs.GetFloat("Audio6", 1);

    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Audio1:
                Audio1VolumePercent = volumePercent;
                break;
            case AudioChannel.Audio2:
                Audio2VolumePercent = volumePercent;
                break;
            case AudioChannel.Audio3:
                Audio3VolumePercent = volumePercent;
                break;
            case AudioChannel.Audio4:
                Audio4VolumePercent = volumePercent;
                break;
            case AudioChannel.Audio5:
                Audio5VolumePercent = volumePercent;
                break;
            case AudioChannel.Audio6:
                Audio6VolumePercent = volumePercent;
                break;
        }

        musicSources[0].volume = Audio1VolumePercent;
        musicSources[1].volume = Audio2VolumePercent;
        musicSources[2].volume = Audio3VolumePercent;
        musicSources[3].volume = Audio4VolumePercent;
        musicSources[4].volume = Audio5VolumePercent;
        musicSources[5].volume = Audio6VolumePercent;

        PlayerPrefs.SetFloat("Audio1", Audio1VolumePercent);
        PlayerPrefs.SetFloat("Audio2", Audio2VolumePercent);
        PlayerPrefs.SetFloat("Audio3", Audio3VolumePercent);
        PlayerPrefs.SetFloat("Audio4", Audio4VolumePercent);
        PlayerPrefs.SetFloat("Audio5", Audio5VolumePercent);
        PlayerPrefs.SetFloat("Audio6", Audio6VolumePercent);
        PlayerPrefs.Save();
    }

 /*      public void ShowAd()
        {
            if (Advertisement.IsReady())          ///////////////////////////////////////////////////////
            {
                Advertisement.Show();
            }
       }
 */
    

    public void TimerMenu()                      ///////////////////////////////////////////////////////
    {
        mainMenuHolder.SetActive(false);
        timerMenuHolder.SetActive(true);
 //       NotificationHolder.SetActive(false);
    }

    public void MainMenu()                       ///////////////////////////////////////////////////////
    {
        mainMenuHolder.SetActive(true);
        timerMenuHolder.SetActive(false);
  //      NotificationHolder.SetActive(false);
    }

    public void SetAudio1Volume(float value)       /////////////////////////////////////////////////////
    {
        SetVolume(value, AudioChannel.Audio1);
    }

    public void SetAudio2Volume(float value)
    {
        SetVolume(value, AudioChannel.Audio2);
    }

    public void SetAudio3Volume(float value)
    {
        SetVolume(value, AudioChannel.Audio3);
    }

    public void SetAudio4Volume(float value)
    {
        SetVolume(value, AudioChannel.Audio4);
    }

    public void SetAudio5Volume(float value)
    {
        SetVolume(value, AudioChannel.Audio5);
    }

    public void SetAudio6Volume(float value)
    {
        SetVolume(value, AudioChannel.Audio6);
    }

    public void CloseTimer1()   //////////////////////////////////////////////////////////
    { 
        SetTimer.SetActive(true);
        InTimer.SetActive(false);
        time = 0;
    }

    public void Timer01()        //////////////////////////////////////////////////////////
    {
        SetTimer.SetActive(false);
        InTimer.SetActive(true);
        time = 900;
    }

    public void Timer02()
    {
        SetTimer.SetActive(false);
        InTimer.SetActive(true);
        time = 1800;
    }

    public void Timer03()
    {
        SetTimer.SetActive(false);
        InTimer.SetActive(true);
        time = 2700;
    }

    public void Timer04()
    {
        SetTimer.SetActive(false);
        InTimer.SetActive(true);
        time = 3600;
    }

    public void Timer05()
    {
        SetTimer.SetActive(false);
        InTimer.SetActive(true);
        time = 7200;
    }


    public void RelaxMusic00()     //////////////////////////////////////////////////////////
    {
        music[0].SetActive(true);
        Text[0].SetActive(false);
        Slider[0].SetActive(true);
        Stop[0].SetActive(true);
    }

    public void RelaxMusic00no()
    {
        music[0].SetActive(false);
        Text[0].SetActive(true);
        Slider[0].SetActive(false);
        Stop[0].SetActive(false);
    }

    public void RelaxMusic01() ///////
    {
        music[1].SetActive(true);
        Text[1].SetActive(false);
        Slider[1].SetActive(true);
        Stop[1].SetActive(true);
    }

    public void RelaxMusic01no()
    {
        music[1].SetActive(false);
        Text[1].SetActive(true);
        Slider[1].SetActive(false);
        Stop[1].SetActive(false);
    }

    public void RelaxMusic02() ///////
    {
        music[2].SetActive(true);
        Text[2].SetActive(false);
        Slider[2].SetActive(true);
        Stop[2].SetActive(true);
    }

    public void RelaxMusic02no()
    {
        music[2].SetActive(false);
        Text[2].SetActive(true);
        Slider[2].SetActive(false);
        Stop[2].SetActive(false);
    }

    public void RelaxMusic03() ///////
    {
        music[3].SetActive(true);
        Text[3].SetActive(false);
        Slider[3].SetActive(true);
        Stop[3].SetActive(true);
    }

    public void RelaxMusic03no()
    {
        music[3].SetActive(false);
        Text[3].SetActive(true);
        Slider[3].SetActive(false);
        Stop[3].SetActive(false);
    }

    public void RelaxMusic04()  ///////
    {
        music[4].SetActive(true);
        Text[4].SetActive(false);
        Slider[4].SetActive(true);
        Stop[4].SetActive(true);
    }

    public void RelaxMusic04no()
    {
        music[4].SetActive(false);
        Text[4].SetActive(true);
        Slider[4].SetActive(false);
        Stop[4].SetActive(false);
    }

    public void RelaxMusic05()  ///////
    {
        music[5].SetActive(true);
        Text[5].SetActive(false);
        Slider[5].SetActive(true);
        Stop[5].SetActive(true);
    }

    public void RelaxMusic05no()
    {
        music[5].SetActive(false);
        Text[5].SetActive(true);
        Slider[5].SetActive(false);
        Stop[5].SetActive(false);
    }
}