using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] GameObject DoorIsClose;
    [SerializeField] GameObject DoorIsOpen;

    Vector2 standartPosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        standartPosition = rb.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rb.velocity = transform.up * -1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("OpenDoor") )
        {
            DoorIsOpen.SetActive(true);
            DoorIsClose.SetActive(false);

            rb.velocity = transform.up / 3;
        }
        if (collision.CompareTag("CloseDoor")) {

            rb.velocity = rb.velocity * 0;
            DoorIsOpen.SetActive(false);
            DoorIsClose.SetActive(true);

        }
    }
   
}
