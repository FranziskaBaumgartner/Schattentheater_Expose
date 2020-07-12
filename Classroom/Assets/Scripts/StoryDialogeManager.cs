using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices.ComTypes;

public class StoryDialogeManager : MonoBehaviour
{
    public TextMeshPro npcDialougeText;

    public float typingSpeed = 0.05f;
    
    [TextArea]
    public string[] npcDialougeSentences;
    public AudioClip[] npcSpeech;

    public Animator npcSpeechbubbleAnimator;

    public int npcIndex;
    private int speechIndex;
    public float SpeechbubbleAnimationsdelay = 0.6f;
    public bool finished = false;

    public GameObject dialogBox;

    public bool continueDialouge=true;

    void Update()
    {
        if(dialogBox.activeSelf==false)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }    
    }
    public IEnumerator StartDialouge()
    {
        continueDialouge = false;
        //npcSpeechbubbleAnimator.SetTrigger("open");
        dialogBox.SetActive(true);
        finished = false;
        yield return new WaitForSeconds(SpeechbubbleAnimationsdelay);
        StartCoroutine(TypeNpcDiaglouge());
    }
   private IEnumerator TypeNpcDiaglouge()
    {
        continueDialouge = false;
        
        speechIndex = npcIndex;
        npcDialougeText.text = string.Empty;
        if (npcSpeech[speechIndex]!= null)
        {
            gameObject.GetComponent<AudioSource>().clip = npcSpeech[speechIndex];
            gameObject.GetComponent<AudioSource>().Play(); 
        }

        foreach (char letter in npcDialougeSentences[npcIndex].ToCharArray())
        {
            npcDialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        npcIndex++;
        continueDialouge = true;
    }

    public void TriggerContinueDialogue()
    {
        continueDialouge = false;
        if (npcIndex == npcDialougeSentences.Length || finished == true)
        {
            npcDialougeText.text = string.Empty;
            //npcSpeechbubbleAnimator.SetTrigger("close");
            dialogBox.SetActive(false);
            finished = true;
        }
        else
            StartCoroutine(ContinueNpcDialouge());
        
    }
    private IEnumerator ContinueNpcDialouge()
    {
        continueDialouge = false;
        yield return new WaitForSeconds(SpeechbubbleAnimationsdelay);
        
        if (npcIndex <= npcDialougeSentences.Length)
        {
           
            npcDialougeText.text = string.Empty;
            StartCoroutine(TypeNpcDiaglouge());
        }
    }

    
}
