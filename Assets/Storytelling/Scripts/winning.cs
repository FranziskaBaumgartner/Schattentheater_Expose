using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{
    public StoryDialogeManager talk;
    public AudioClip bling;
    public Animator inventory;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        talk = talk.GetComponent<StoryDialogeManager>();
        

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnMouseDown()
    {
        if (talk.finished)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<AudioSource>().clip=bling;
            gameObject.GetComponent<AudioSource>().Play();
            talk.npcIndex = 4;
            talk.StartCoroutine(talk.StartDialouge());
            inventory.SetTrigger("gotIt");
            won = true;


        }
    }




}
