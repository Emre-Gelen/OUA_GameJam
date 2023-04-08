using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : UIElement
{
    public TMP_Text ScoreDisplayText;

    public override void OnUIUpdate()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (ScoreDisplayText != null)
        {
            ScoreDisplayText.text = GameManager.score.ToString();
        }
    }
}
