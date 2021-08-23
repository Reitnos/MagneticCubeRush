using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class RetryButton : MonoBehaviour
{
    private int currentLevel;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void PlayAgain()
       {
           GameAnalytics.NewProgressionEvent (GAProgressionStatus.Start,  "Level " + currentLevel.ToString() + " Re-tried"); 
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
}
