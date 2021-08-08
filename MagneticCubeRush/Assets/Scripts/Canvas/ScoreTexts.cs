using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreTexts : MonoBehaviour
{
    int _playerScore = 0;
    
    int _enemyScore = 0;

    public event Action<int> enemyScoreChanged;
    public event Action<int> playerScoreChanged;

    private static ScoreTexts _instance;

    public static ScoreTexts Instance()
    {
        return _instance; 
    }

    private void OnEnable()
    {
        if (!_instance)
        {
            _instance = this;
        }
     
    }

    public int PlayerScore
    {
        get => _playerScore;
       
    }
    public int EnemyScore
    {
        get => _enemyScore;
       
    }
    

    public void IncreasePlayerScore(int incrementValue)
    {
        _playerScore += incrementValue;
        PlayerScoreChanged();
    }
    public void IncreaseEnemyScore(int incrementValue)
    {
        
        _enemyScore += incrementValue;
        EnemyScoreChanged();
    }

    private void PlayerScoreChanged()
    {
        playerScoreChanged?.Invoke(_playerScore);
    }
    private void EnemyScoreChanged()
    {
        enemyScoreChanged?.Invoke(_enemyScore);
    }
    
}
