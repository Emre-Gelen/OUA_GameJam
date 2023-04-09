using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;

    public float typingSpeed;
    public GameObject continueButton;

    private int index;

    void Start()
    {
        StartCoroutine(Type());
        continueButton.SetActive(false);
    }

    void Update()
    {
        if (textDisplay.text == sentences[index]) { 
        
            continueButton.SetActive(true);
        }

    }

    IEnumerator Type()
    {
        // Harf harf yazim hizi icin
        foreach (char lettern in sentences[index].ToCharArray())
        {
            textDisplay.text += lettern;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(true);

        //Continue butonunda bi sonraki cumleye gecmeye
        if (index < sentences.Length - 1)
        {
            continueButton.SetActive(false);
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
