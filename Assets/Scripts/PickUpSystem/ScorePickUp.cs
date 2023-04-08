using System;
using UnityEngine;

public class ScorePickUp : PickUp
{
    public int Score = 50; 

    public override void HandlePickUp(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.AddScore(Score);
        }
        base.HandlePickUp(collision);
    }
}

