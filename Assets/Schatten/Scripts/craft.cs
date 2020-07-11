using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public SpriteRenderer cloud;
    public Animator dust;
    [SerializeField] private SpriteChanger yellow;

    public AudioSource pong;
    public AudioSource rumble;
    public AudioSource heavy;
    public AudioSource twinkle;

    public bool build = false;

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
        yellow = yellow.GetComponent<SpriteChanger>();
    }

    void Update()
    {
        if(talk.finished&&!build)
            yellow.isActive = true;
        else
            yellow.isActive = false;

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
            build = false;
            count++;
            switch (count)
            {
                case 50:
                    first.SetActive(false);
                    break;
                case 100:
                    rumble.Play();
                    break;
                case 110:
                    tinyfirst.enabled = true;
                    break;


                case 150:
                    third.SetActive(false);
                    break;
                case 200:
                    pong.Play();
                    break;
                case 210:
                    tinythird.enabled = true;
                    break;


                case 250:
                    second.SetActive(false);
                    break;
                case 300:
                    heavy.Play();
                    break;
                case 310:
                    tinysecond.enabled = true;
                    break;


                case 500:
                    
                    cloud.GetComponent<SpriteRenderer>().enabled = true;
                    dust.GetComponent<Animator>().SetTrigger("craftin");
                    gameObject.GetComponent<AudioSource>().Play();
                    break;


                case 850:
                    twinkle.Play();
                    cloud.GetComponent<SpriteRenderer>().enabled = false;
                    break;
                case 930:
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
