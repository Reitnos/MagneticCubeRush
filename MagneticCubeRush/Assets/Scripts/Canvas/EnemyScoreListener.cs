using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScoreListener : MonoBehaviour
{
    private string _enemyScore;
    void Start()
    {
        ScoreTexts.Instance().enemyScoreChanged += ChangeScore;
    }

    private void ChangeScore(int lastScore)
    {
        _enemyScore = lastScore.ToString();
        GetComponent<TextMeshProUGUI>().text = _enemyScore;
    }
    private void OnDestroy()
    {
        ScoreTexts.Instance().enemyScoreChanged -= ChangeScore;
    }
}
