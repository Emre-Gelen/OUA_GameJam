using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private int gameManagerScore = 0;

    [SerializeField] private UIManager _UIManager;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Static getter/setter for player score (for convenience)
    public static int score
    {
        get
        {
            return instance.gameManagerScore;
        }
        set
        {
            instance.gameManagerScore = value;
        }
    }

    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        instance._UIManager.UpdateUI();
    }
}

