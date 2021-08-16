using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    
    private ScoreTexts scoreScript;
    private SceneCubeCount cubeCountScript;
    public GameObject levelFinishAnimation;
    void Start()
    {
        scoreScript = FindObjectOfType<ScoreTexts>();
        cubeCountScript = FindObjectOfType<SceneCubeCount>();
    }

    private void LateUpdate()
    {
        CheckScoreAndGoNextLevel();
    }

    private void CheckScoreAndGoNextLevel()
    {
        if (scoreScript.EnemyScore >= Math.Ceiling(cubeCountScript.GetCount() / 2f))
        {
            LoadThisSceneAgain();
        }
        if (scoreScript.PlayerScore + scoreScript.EnemyScore >= cubeCountScript.GetCount())
        {
            if (scoreScript.PlayerScore > scoreScript.EnemyScore) 
            {
                levelFinishAnimation.SetActive(true);
                Invoke("LoadNextScene",2f);

            }
           
            
        }
    }

    private void LoadThisSceneAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
