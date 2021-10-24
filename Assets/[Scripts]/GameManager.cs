using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //variables
    public static GameManager Instance;
    //public Rect screen;
    //public Rect safeArea;
    
    private bool paused1;
    //public Rect backButtonRect;
    // public Button backButton;
    Scene scene;
    public AudioClip MainSoundTrack;
    public AudioClip PauseSoundTrack;
    private AudioSource audioSource;
    void Start()
    {
        //screen = Screen.safeArea;
        //Debug.Log(backButton.transform.localPosition);
        audioSource = GetComponent<AudioSource>();
        Instance = this;
        paused1 = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        UpdateSound();
        Cursor.visible = true;
        scene = SceneManager.GetActiveScene();
        Rect Screenrect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
        //screen = Screenrect;
        //safeArea = Screen.safeArea;

        //checkScreenOrientation();
        //Debug.Log(Screen.orientation);

    }
    //private static void checkScreenOrientation()
    //{
    //    switch (Screen.orientation)
    //    {
    //        case ScreenOrientation.LandscapeLeft:
    //            break;
    //        case ScreenOrientation.LandscapeRight:
    //            break;
    //        case ScreenOrientation.Portrait:
    //            break;
    //        default:
    //            break;
    //    }
    //    Debug.Log(Screen.orientation);
    //}
    public void OnPause()
    {
        paused1 = true;
        //paused2 = false;
        Time.timeScale = 0.0f;
        UpdateSound();
    }

    public void OnResume()
    {
        paused1 = false;
        //paused2 = true;
        Time.timeScale = 1.0f;
        UpdateSound();
    }

    public void OnRestart()
    {
        
        UpdateSound();
        SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
        
    }

    public void Exit()
    {
        Application.Quit();
    }
   
    public void Win()
    {
        
    
        UpdateSound();
       
    }
    private void UpdateSound()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (!paused1) // play song 1
        {
            audioSource.clip = MainSoundTrack;
            audioSource.Play(0);
            audioSource.volume = 0.7f;
            //paused2 = true;
        }
        if (paused1) //song 1 paused 
        {
            audioSource.Pause();
            //paused2 = false;
            audioSource.clip = PauseSoundTrack;
            audioSource.volume = 0.3f;
            audioSource.Play(0);
        }
    }
}
