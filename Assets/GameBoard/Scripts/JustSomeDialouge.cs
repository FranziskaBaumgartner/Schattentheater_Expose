using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class JustSomeDialouge : MonoBehaviour
{
    public bool playerInRange;

    public StoryDialogeManager storyTalk;
    // Start is called before the first frame update
    void Start()
    {
        storyTalk = storyTalk.GetComponent<StoryDialogeManager>();
        storyTalk.continueDialouge = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (storyTalk.dialogBox.activeSelf == false)
        {
            storyTalk.gameObject.GetComponent<AudioSource>().Pause();
        }
        

        if (this.gameObject.tag == "talkative" && playerInRange && storyTalk.continueDialouge)
        {
            storyTalk.StartCoroutine(storyTalk.StartDialouge());
            storyTalk.npcIndex = 0;
            storyTalk.npcDialougeText.text = string.Empty;
        }
        if (this.gameObject.tag == "mentor" && playerInRange && storyTalk.continueDialouge)
        {
            if (storyTalk.npcIndex > 0)
                storyTalk.npcDialougeText.text = storyTalk.npcDialougeSentences[0];
            else
                storyTalk.StartCoroutine(storyTalk.StartDialouge());


            if (Input.GetKeyDown(KeyCode.Space) )
            {
                if(storyTalk.dialogBox.activeSelf)
                    storyTalk.dialogBox.SetActive(false);
                else
                    storyTalk.dialogBox.SetActive(true);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
