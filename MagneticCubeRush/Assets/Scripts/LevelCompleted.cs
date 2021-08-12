using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    
    private ScoreTexts scoreScript;
    void Start()
    {
        scoreScript = FindObjectOfType<ScoreTexts>();
    }

    private void LateUpdate()
    {
        CheckScoreAndGoNextLevel();
    }

    private void CheckScoreAndGoNextLevel()
    {
        if (scoreScript.PlayerScore + scoreScript.EnemyScore >= NumberOfCubesInScene.numOfCubes)
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
