using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleManager : MonoBehaviour
{
    int piece = 0;
    int sum = 25;


    // Oyunun bitmesinin kontrolu
    public void numberIncrease() {

        piece++;

        if (sum == piece)
        {

            SceneManager.LoadScene("Bo2");

        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
