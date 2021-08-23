using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class LevelCompleted : MonoBehaviour
{
    private int currentLevel;
    private ScoreTexts scoreScript;
    private SceneCubeCount cubeCountScript;
    public GameObject levelFinishAnimationWin;
    public GameObject levelFinishAnimationLose;
    void Start()
    {
        GameAnalytics.Initialize();
        scoreScript = FindObjectOfType<ScoreTexts>();
        cubeCountScript = FindObjectOfType<SceneCubeCount>();
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void LateUpdate()
    {
        CheckScoreAndGoNextLevel();
    }

    private void CheckScoreAndGoNextLevel()
    {
        if (scoreScript.EnemyScore >= Math.Ceiling(cubeCountScript.GetCount() / 2f))
        {
            levelFinishAnimationLose.SetActive(true);
            
            Invoke("LoadThisSceneAgain",2f);
        }
        if (scoreScript.PlayerScore + scoreScript.EnemyScore >= cubeCountScript.GetCount())
        {
            if (scoreScript.PlayerScore > scoreScript.EnemyScore) 
            {
                levelFinishAnimationWin.SetActive(true);
                Invoke("LoadNextScene",2f);

            }
           
            
        }
    }

    private void LoadThisSceneAgain()
    {
        GameAnalytics.NewProgressionEvent (GAProgressionStatus.Start,  "Level " + currentLevel.ToString() + " Failed"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        GameAnalytics.NewProgressionEvent (GAProgressionStatus.Complete,  "Level " + currentLevel.ToString() + " Completed"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
