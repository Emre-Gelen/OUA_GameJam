using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movePic : MonoBehaviour
{
    Camera camera;
    Vector2 firstPosition;
    GameObject[] box_array;
    int piece = 0;
    int sum = 25;

   // puzzleManager manager;

    private void OnMouseDrag()
    {
        Vector3 position = camera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;
    }

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        firstPosition = transform.position;

        box_array = GameObject.FindGameObjectsWithTag("puzzleBox");
      //  manager = GameObject.Find("puzzleManager").GetComponent<puzzleManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) { 
        
            foreach (GameObject boxx in box_array) {
            
                if (boxx.name == gameObject.name)
                {

                    float distance = Vector3.Distance(boxx.transform.position, transform.position);

                    if (distance <= 1)
                    {

                        transform.position = boxx.transform.position;
                        // manager.numberIncrease();
                        // this.enabled = false;
                        piece++;
                    }
                    else {

                        transform.position = firstPosition;
                    }

                }
            }
            
        }

        if (sum == piece) {

            Debug.Log("Game Over");
        }
    }
}
