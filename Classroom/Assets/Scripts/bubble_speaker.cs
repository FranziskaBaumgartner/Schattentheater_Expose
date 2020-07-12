using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;


public class bubble_speaker : MonoBehaviour
{
    private Animator anim;
    public StoryDialogeManager dialouge;
    public TextMeshPro DialougeText;
    public Text text;
    public SpriteRenderer dialogBox;

    public bool dialougeStarted = false;
    public bool speaker_dialouge_finished;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        dialouge = dialouge.GetComponent<StoryDialogeManager>(); 
        dialogBox = dialogBox.GetComponent<SpriteRenderer>(); 
        speaker_dialouge_finished = false;
        //text=GameObject.Find("Text_instruction").GetComponent<Text>(); 

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HandleIt());
    }

    private IEnumerator HandleIt()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("bubble_speaker"))
        {
            //Debug.Log("running");
        }
        else
        {
            if(dialougeStarted==false)
            {
                //Debug.Log("ende");
                
                dialouge.dialogBox = gameObject;
                dialouge.npcDialougeText = DialougeText;
                dialouge.npcIndex = 2;
                dialouge.SpeechbubbleAnimationsdelay = 0.6f;

                dialouge.StartCoroutine(dialouge.StartDialouge());
                dialouge.SpeechbubbleAnimationsdelay = 2.0f;

                dialougeStarted = true;
            }
            else
            {
                if (dialouge.npcIndex < 5 && dialouge.continueDialouge == true)
                {
                    dialouge.TriggerContinueDialogue();
                }
                else
                {
                    if (dialouge.npcIndex == 5 && speaker_dialouge_finished == false)
                    {
                        yield return new WaitForSeconds( 2.0f );
                        dialouge.finished = true;
                        dialouge.TriggerContinueDialogue();
                        speaker_dialouge_finished = true;
                    }
                }
            }
            if (speaker_dialouge_finished)
            {
                dialogBox.enabled = true;
                text.enabled=true;
            }
        }
    }
}
