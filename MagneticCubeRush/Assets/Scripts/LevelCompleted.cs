using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public int numOfCubesToPass;
    private ScoreTexts scoreScript;
    void Start()
    {
        scoreScript = FindObjectOfType<ScoreTexts>();
    }

    private void Update()
    {
        CheckScoreAndGoNextLevel();
    }

    private void CheckScoreAndGoNextLevel()
    {
        if (scoreScript.PlayerScore + scoreScript.EnemyScore >= numOfCubesToPass)
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
