using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpEffect;
    public AudioClip PickUpSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePickUp(collision);
    }

    public virtual void HandlePickUp(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PickUpEffect != null)
            {
                Instantiate(PickUpEffect, transform.position, Quaternion.identity, null);
            }

            if (PickUpSoundEffect != null)
            {
                AudioSource.PlayClipAtPoint(PickUpSoundEffect, transform.position);
            }

            Destroy(this.gameObject);
        }
    }
}
