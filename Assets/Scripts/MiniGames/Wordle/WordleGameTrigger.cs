using UnityEngine;

public class WordleGameTrigger : PickUp
{
    public override void HandlePickUp(Collider2D collision)
    {
        yonetici.StartWordle();
        base.HandlePickUp(collision);
    }
}
