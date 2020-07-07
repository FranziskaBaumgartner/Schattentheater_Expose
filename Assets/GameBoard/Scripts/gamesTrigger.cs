using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamesTrigger : MonoBehaviour
{
    public StoryDialogeManager storyTalk;
    // Start is called before the first frame update
    void Start()
    {
        storyTalk = storyTalk.GetComponent<StoryDialogeManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "storyTrigger")
        {
            storyTalk.StartCoroutine(storyTalk.StartDialouge());
        }
        
    }
}
