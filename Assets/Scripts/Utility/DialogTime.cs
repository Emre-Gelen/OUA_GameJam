using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTime : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    // public GameObject continueButton;
   // public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(Type());


    }

    void Update()
    {

        if (textDisplay.text == sentences[index])
        {
            //     continueButton.SetActive(true);

            NextSentence();

        }
    }

    IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }

    public void NextSentence()
    {

        // continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            //audioSource.Play();
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            //  continueButton.SetActive(false);
        }

    }


}