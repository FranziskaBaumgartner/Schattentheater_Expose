using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryDialogeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcDialougeText;

    [SerializeField] private float typingSpeed = 0.05f;
    
    [TextArea]
    [SerializeField] private string[] npcDialougeSentences;

    [SerializeField] private AudioClip[] npcSpeech;

    [SerializeField] private GameObject continueButton;

    [SerializeField] private Animator npcSpeechbubbleAnimator;

    public int npcIndex;
    private int speechIndex;
    public float SpeechbubbleAnimationsdelay = 0.6f;
    public bool finished = false;


    public IEnumerator StartDialouge()
    {
        npcSpeechbubbleAnimator.SetTrigger("open");
        finished = false;
        yield return new WaitForSeconds(SpeechbubbleAnimationsdelay);
        StartCoroutine(TypeNpcDiaglouge());
    }
   private IEnumerator TypeNpcDiaglouge()
    {
        speechIndex = npcIndex;
        npcDialougeText.text = string.Empty;
        gameObject.GetComponent<AudioSource>().clip = npcSpeech[speechIndex];
        gameObject.GetComponent<AudioSource>().Play();
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
        if(npcIndex>= 3)
        {
            npcDialougeText.text = string.Empty;
            npcSpeechbubbleAnimator.SetTrigger("close");
            finished = true;
        }
        else
        {
            StartCoroutine(ContinueNpcDialouge());
        }
    }
}
