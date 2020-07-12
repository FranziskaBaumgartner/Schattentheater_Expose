using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public SpriteRenderer theatherFront;
    public SpriteRenderer cloud;
    public Animator dust;
    [SerializeField] private SpriteChanger yellow;

    public AudioSource pong;
    public AudioSource rumble;
    public AudioSource heavy;
    public AudioSource twinkle;

    public bool build = false;

    private int count = 0;

    private bool twinkleFinished = false;
    private bool craftinFinished = false;
    private bool rumbleFinished = false;
    private bool pongFinished = false;
    private bool heavyFinished = false;
    public bool theaterAvailable = false;
    void Start()
    {
        talk.GetComponent<StoryDialogeManager>();
        pong = pong.GetComponent<AudioSource>();
        rumble = rumble.GetComponent<AudioSource>();
        heavy = heavy.GetComponent<AudioSource>();
        twinkle = twinkle.GetComponent<AudioSource>();
        theather = theather.GetComponent<SpriteRenderer>();
        theatherFront = theatherFront.GetComponent<SpriteRenderer>();
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

        if (count >0&&count<=13)
        {
            build = true;
            StartCoroutine(craftin());
        }
    }

    private IEnumerator craftin()
    {
        switch (count)
        {
            case 1:
                
                first.SetActive(false);
                yield return new WaitForSeconds(0.06f);
                count=2;
                break;

            case 2:
                if (!rumble.isPlaying && !rumbleFinished)
                    rumble.Play();
                if (rumble.isPlaying)
                    rumbleFinished = true;
                yield return new WaitForSeconds(0.24f);
                count=3;
                break;
            case 3:
                tinyfirst.enabled = true;
                yield return new WaitForSeconds(0.6f);
                count=4;
                break;


            case 4:
                third.SetActive(false);
                yield return new WaitForSeconds(0.06f);
                count=5;
                break;
            case 5:
                if (!pong.isPlaying && !pongFinished)
                    pong.Play();
                if (pong.isPlaying)
                    pongFinished = true;
                yield return new WaitForSeconds(0.24f);
                count=6;
                break;
            case 6:
                tinythird.enabled = true;
                yield return new WaitForSeconds(0.6f);
                count=7;
                break;


            case 7:
                second.SetActive(false);
                yield return new WaitForSeconds(0.06f);
                count=8;
                break;
            case 8:
                if (!heavy.isPlaying && !heavyFinished)
                    heavy.Play();
                if (heavy.isPlaying)
                    heavyFinished = true;
                yield return new WaitForSeconds(0.24f);
                count=9;
                break;
            case 9:
                tinysecond.enabled = true;
                yield return new WaitForSeconds(0.6f);
                count=10;
                break;


            case 10:
                cloud.GetComponent<SpriteRenderer>().enabled = true;
                dust.GetComponent<Animator>().SetTrigger("craftin");
                if (!gameObject.GetComponent<AudioSource>().isPlaying && !craftinFinished)
                    gameObject.GetComponent<AudioSource>().Play();
                if (gameObject.GetComponent<AudioSource>().isPlaying)
                    craftinFinished = true;
                yield return new WaitForSeconds(2f);
                count=11;
                break;


            case 11:
               
                if (!twinkle.isPlaying&&!twinkleFinished)
                    twinkle.Play();
                if (twinkle.isPlaying)
                    twinkleFinished = true;
                cloud.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.5f);
                count=12;
                break;
            case 12:
                theather.enabled = true;
                theatherFront.enabled = true;
                hover = -2;
                count = 13;
                break;
            case 13:
                talk.npcIndex = 4;
                if(talk.finished)
                    talk.StartCoroutine(talk.StartDialouge());
                theaterAvailable = true;
                count = 14;
                break;
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
