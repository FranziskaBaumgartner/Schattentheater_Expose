using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class speaker : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && storyTalk.npcIndex == 0&& storyTalk.continueDialouge)
        {
            storyTalk.StartCoroutine(storyTalk.StartDialouge());
        }

        else if (Input.GetKeyDown(KeyCode.Space) && playerInRange && storyTalk.continueDialouge)
            storyTalk.TriggerContinueDialogue();


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
