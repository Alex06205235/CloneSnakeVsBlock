using Skripts.Control;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText1 : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = $@"Level {(Finish.LevelIndex + 1)}";

    }
}
