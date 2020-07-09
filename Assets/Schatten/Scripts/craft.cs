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
        tinyfirst = theather.GetComponent<SpriteRenderer>();
        tinysecond = theather.GetComponent<SpriteRenderer>();
        tinythird = theather.GetComponent<SpriteRenderer>();
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

                case 55:
                    rumble.Play();
                    break;

                case 105:
                    tinyfirst.enabled = true;
                    break;
                case 155:
                    third.SetActive(false);
                    break;
                case 160:
                    pong.Play();
                    break;
                case 210:
                    tinythird.enabled = true;
                    break;
                case 260:
                    second.SetActive(false);
                    break;
                case 265:
                    heavy.Play();
                    break;
                case 315:
                    tinysecond.enabled = true;
                    break;
                case 365:
                    twinkle.Play();
                    break;
                case 370:
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 4000:
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
