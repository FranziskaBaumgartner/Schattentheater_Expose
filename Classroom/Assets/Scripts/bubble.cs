using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{

    private Animator anim;
    public StoryDialogeManager dialouge;
    public bool dialougeStarted=false;
    public bool dialougeContinue=true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        dialouge = dialouge.GetComponent<StoryDialogeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("bubble"))
        {
            Debug.Log("running");
        }
        else
        {
            if(dialougeStarted==false)
            {
                Debug.Log("ende");
                
                dialouge.npcIndex = 0;

                dialouge.StartCoroutine(dialouge.StartDialouge());
                dialougeStarted = true;
            }
            else
            {
                if (dialouge.continueDialouge==true)
                {
                    dialouge.TriggerContinueDialogue();
                    dialougeContinue = false;

                }
            }
        }
    }
}
