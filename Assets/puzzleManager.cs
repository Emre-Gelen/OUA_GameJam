using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{
    int piece = 0;
    int sum = 25;


    // Oyunun bitmesinin kontrolu
    public void numberIncrease() {

        piece++;

        if (sum == piece)
        {

            Debug.Log("Completed!");

        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
