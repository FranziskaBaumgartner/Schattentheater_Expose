using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craft : MonoBehaviour
{

    public int hover = 0;
    public StoryDialogeManager talk;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public SpriteRenderer tinyfirst;
    public SpriteRenderer tinysecond;
    public SpriteRenderer tinythird;
    public SpriteRenderer theather;

    public AudioSource pong;
    public AudioSource rumble;
    public AudioSource heavy;
    public AudioSource twinkle;

    private int count = 0;
    void Start()
    {
        talk.GetComponent<StoryDialogeManager>();
        pong = pong.GetComponent<AudioSource>();
        rumble = rumble.GetComponent<AudioSource>();
        heavy = heavy.GetComponent<AudioSource>();
        twinkle = twinkle.GetComponent<AudioSource>();
        theather = theather.GetComponent<SpriteRenderer>();
        tinyfirst = tinyfirst.GetComponent<SpriteRenderer>();
        tinysecond = tinysecond.GetComponent<SpriteRenderer>();
        tinythird = tinythird.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (hover == 1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                count = 1;
                
            }

        }
        else if (hover == 0)
        {

            gameObject.GetComponent<AudioSource>().Stop();

        }
        if (count >0)
        {
            count++;
            switch (count)
            {
                case 50:
                    first.SetActive(false);
                    break;

                case 60:
                    rumble.Play();
                    break;

                case 120:
                    tinyfirst.enabled = true;
                    break;
                case 130:
                    third.SetActive(false);
                    break;
                case 190:
                    tinythird.enabled = true;
                    break;
                case 200:
                    pong.Play();
                    break;
                case 260:
                    second.SetActive(false);
                    break;
                case 270:
                    heavy.Play();
                    break;
                case 330:
                    tinysecond.enabled = true;
                    break;
                case 340:
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 420:
                    twinkle.Play();
                    break;
                case 440:
                    theather.enabled = true;
                    hover = -2;
                    break;
            }
               
          
          
            
            
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
