using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lernKasten : MonoBehaviour
{
    public AudioSource Kind;
    public int hover = 0;
    public bool won = false;
    public StoryDialogeManager talk;
    // Start is called before the first frame update
    void Start()
    {
        Kind.GetComponent<AudioSource>();
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
        if (col.gameObject.CompareTag("Kind"))
        {
            won = true;
            Kind.Play();

        }
    }
    private void OnTriggerStay2D(Collider2D other)
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
