using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //variables
    public Rect screen;
    public Rect safeArea;
    public Rect backButtonRect;
    public Button backButton;
    void Start()
    {
        //screen = Screen.safeArea;
        Debug.Log(backButton.transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
       
        Rect Screenrect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
        screen = Screenrect;
        safeArea = Screen.safeArea;

        checkScreenOrientation();
        Debug.Log(Screen.orientation);

    }
    private static void checkScreenOrientation()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                break;
            case ScreenOrientation.LandscapeRight:
                break;
            case ScreenOrientation.Portrait:
                break;
            default:
                break;
        }
        Debug.Log(Screen.orientation);
    }
}
