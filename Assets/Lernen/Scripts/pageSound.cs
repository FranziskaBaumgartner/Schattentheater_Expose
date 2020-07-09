using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageSound : MonoBehaviour
{
    
    public int hover = 0;
    public StoryDialogeManager talk;

    void Start()
    {
        talk.GetComponent<StoryDialogeManager>();
    }

    void Update()
    {

        if (hover == 1)
        {
            gameObject.GetComponent<AudioSource>().Play();
            
            hover = -2;

        }
        else if (hover == 0)
        {

            gameObject.GetComponent<AudioSource>().Stop();

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (talk.finished)
        {
            
            if (hover == 0)
                hover = 1;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (talk.finished)
        {
            hover = 0;
        }
    }


}
