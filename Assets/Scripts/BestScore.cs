using Skripts.Score;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    ScoresComponent _scoresComponent;
    public TextMeshProUGUI bestScoreText;
    private const string BestScoresKey = "BestScores";

    private static int BestScores
    {
        get => PlayerPrefs.GetInt(BestScoresKey, 0);
        set
        {
            PlayerPrefs.SetInt(BestScoresKey, value);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        _scoresComponent = FindObjectOfType<ScoresComponent>();
        var scores = _scoresComponent.Current;
        if (scores <= BestScores)
        {
            bestScoreText.text = " " + BestScores;
            return;
        };
        BestScores = scores;
        bestScoreText.text = " " + BestScores;
    }
}
