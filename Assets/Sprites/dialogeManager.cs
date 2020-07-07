﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcDialougeText;

    [SerializeField] private float typingSpeed = 0.05f;
    
    [TextArea]
    [SerializeField] private string[] npcDialougeSentences;
    
    [SerializeField] private GameObject continueButton;

    [SerializeField] private Animator npcSpeechbubbleAnimator;

    private int npcIndex;
    private float SpeechbubbleAnimationsdelay = 0.6f;


    private void Start()
    {
        StartCoroutine(StartDialouge());
    }

    private IEnumerator StartDialouge()
    {
        npcSpeechbubbleAnimator.SetTrigger("open");
        yield return new WaitForSeconds(SpeechbubbleAnimationsdelay);
        StartCoroutine(TypeNpcDiaglouge());
    }
   private IEnumerator TypeNpcDiaglouge()
    {
        foreach (char letter in npcDialougeSentences[npcIndex].ToCharArray())
        {
            npcDialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    private IEnumerator ContinueNpcDialouge()
    {
        yield return new WaitForSeconds(SpeechbubbleAnimationsdelay);
        continueButton.SetActive(false);
        if (npcIndex < npcDialougeSentences.Length - 1)
        {
            npcIndex++;
            npcDialougeText.text = string.Empty;
            StartCoroutine(TypeNpcDiaglouge());
        }
    }

    public void TriggerContinueDialogue()
    {
        if(npcIndex>= npcDialougeSentences.Length - 1)
        {
            npcDialougeText.text = string.Empty;
            npcSpeechbubbleAnimator.SetTrigger("close");
        }
        else
        {
            StartCoroutine(ContinueNpcDialouge());
        }
    }
}