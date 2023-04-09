using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartTrigger : PickUp
{
    public override void HandlePickUp(Collider2D collision)
    {
        PuzzleControl.StartPuzzle();
        base.HandlePickUp(collision);
    }
}
