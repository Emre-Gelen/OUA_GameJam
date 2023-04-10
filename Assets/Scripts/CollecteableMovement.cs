using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecteableMovement : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0.05f;

    void Update()
    {
        Vector3 pos = transform.position;

        float newY = Mathf.Sin(Time.time * speed);

        newY = newY * height;
        newY += pos.y;

        transform.position = new Vector3(pos.x,  newY, pos.z);
    }
}
