using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    
    private ScoreTexts scoreScript;
    private SceneCubeCount cubeCountScript;
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
        
        if (scoreScript.PlayerScore + scoreScript.EnemyScore >= cubeCountScript.GetCount())
        {
            if (scoreScript.PlayerScore > scoreScript.EnemyScore) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
            }
            else
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }
}
