using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonBehaviour : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        Debug.Log("Start Button Pressed!");
        SceneManager.LoadScene("Main");
    }
}
