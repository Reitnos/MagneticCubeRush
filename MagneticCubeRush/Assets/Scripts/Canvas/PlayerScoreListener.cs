using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreListener : MonoBehaviour
{
    private string _playerScore;
    void Start()
    {
        ScoreTexts.Instance().playerScoreChanged += ChangeScore;
    }

    private void ChangeScore(int lastScore)
    {
        _playerScore = lastScore.ToString();
        GetComponent<TextMeshProUGUI>().text = _playerScore;
    }
}
