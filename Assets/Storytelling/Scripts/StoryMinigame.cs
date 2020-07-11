using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMinigame : MonoBehaviour
{
    private int hover = 0;
    public AudioClip wrong;
    public AudioClip picClip;
    public StoryDialogeManager talk;
    public winningStory state;

    public Animator video;

    [SerializeField] private SpriteChanger yellow;


    // Start is called before the first frame update
    void Start()
    {
        talk = talk.GetComponent<StoryDialogeManager>();
        state = state.GetComponent<winningStory>();
        yellow = yellow.GetComponent<SpriteChanger>();
        
    }

        // Update is called once per frame
    void Update()
    {
        if(talk.finished&&!state.won)
            yellow.isActive = true;
        else
            yellow.isActive = false;

        if (Input.GetKeyDown(KeyCode.Space)&&hover==-2&&!state.won)
        {
            if (this.gameObject.tag != "glas" && talk.finished && !state.won)
            {
                gameObject.GetComponent<AudioSource>().clip = wrong;
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<AudioSource>().clip = picClip;

                if (talk.npcIndex > 7)
                    talk.npcIndex = 5;

                if(talk.npcIndex == 4)
                    talk.npcIndex = 5;
                
                talk.StartCoroutine(talk.StartDialouge());
            }
            
        }
        if (hover == 1)
        {
            
            gameObject.GetComponent<AudioSource>().Play();
            hover = -2;
          
            

        }
        else if (hover == 0)
        {

            gameObject.GetComponent<AudioSource>().Stop();
            if (this.gameObject.tag == "vid")
                video.SetTrigger("left");
        }


        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            if (this.gameObject.tag == "vid")
                video.SetTrigger("mouseOver");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (talk.finished&&!state.won)
        {
            if (this.gameObject.tag == "vid")
                this.GetComponent<Animator>().enabled = true;
            if (hover == 0)
                hover = 1;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (talk.finished)
            hover = 0;
        
    }







}
