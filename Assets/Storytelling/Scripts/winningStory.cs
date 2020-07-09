using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningStory : MonoBehaviour
{
    public StoryDialogeManager talk;
    public AudioClip bling;
    //public Animator inventory;
    public bool won = false;
    private bool hover;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        talk = talk.GetComponent<StoryDialogeManager>();
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&hover&&!won)
        {
            win();
        }
        
    }
    private void OnTriggerEnter2D()
    {
        hover = true; 
    }
    private void OnTriggerExit2D()
    {
        hover = false;
        
    }

    public void win()
    {

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<AudioSource>().clip = bling;
        gameObject.GetComponent<AudioSource>().Play();
        talk.npcIndex = 4;
        talk.StartCoroutine(talk.StartDialouge());
        inventory.SetActive(true);
        //inventory.SetTrigger("gotIt");
        gameObject.GetComponent<AudioSource>().mute = true;
        won = true;

    }



}
