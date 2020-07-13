using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bubble : MonoBehaviour
{

    private Animator anim;
    public StoryDialogeManagerClassroom dialouge;
    public TextMeshPro DialougeText;

    public bubble_speaker bubble_Speaker;

    public bool dialougeStarted=false;

    private bool thinking_dialouge_finished = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        dialouge = dialouge.GetComponent<StoryDialogeManagerClassroom>();
        bubble_Speaker = bubble_Speaker.GetComponent<bubble_speaker>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HandleIt());
    }

    private IEnumerator HandleIt()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("bubble"))
        {
            //Debug.Log("running");
        }
        else
        {
            if(dialougeStarted==false)
            {
                //Debug.Log("ende");
                
                dialouge.npcIndex = 0;

                dialouge.StartCoroutine(dialouge.StartDialouge());
                dialougeStarted = true;
            }
            else
            {
                if (dialouge.npcIndex < 2 && dialouge.continueDialouge == true)
                {
                    dialouge.TriggerContinueDialogue();
                }
                else
                {
                    if (dialouge.npcIndex == 2 && thinking_dialouge_finished == false)
                    {
                        yield return new WaitForSeconds( 2.0f );
                        dialouge.finished = true;
                        dialouge.TriggerContinueDialogue();
                        thinking_dialouge_finished = true;
                        dialougeStarted = false;
                    }
                }
            }
        }
    }
}
