using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishConrol : MonoBehaviour
{
    int piece = 0;
    int sum = 20;


    // Oyunun bitmesinin kontrolu
    public void numberIncrease()
    {

        piece++;

        if (sum == piece)
        {

            SceneManager.LoadScene("LastScene");

        }

    }
}
