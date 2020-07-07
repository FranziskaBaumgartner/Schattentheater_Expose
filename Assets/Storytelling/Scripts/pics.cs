using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pics : MonoBehaviour
{
    private int hover = 0;
    public AudioClip wrong;
    public AudioClip picClip;
    public dialogeManager talk;
    public winning state;
    // Start is called before the first frame update
    void Start()
    {
        talk = talk.GetComponent<dialogeManager>();
        state = state.GetComponent<winning>();
    }

        // Update is called once per frame
    void Update()
    {
        if (hover == 1)
        {
            hover = -2;
            gameObject.GetComponent<AudioSource>().Play();
            
            if (this.gameObject.tag == "vid")
            {
                print("animon");
                gameObject.GetComponent<Animator>().SetTrigger("mouseOver");
            }

        }
        else if (hover == 0)
        {

            gameObject.GetComponent<AudioSource>().Stop();
        }

    }

    private void OnMouseOver()
    {
        if (talk.finished)
        {
            if (hover == 0)
                hover = 1;
            
        }
       
    }
    private void OnMouseExit()
    {
        if (talk.finished)
        {
            hover = 0;
        }
    }

    private void OnMouseDown()
    {
        if (this.gameObject.tag!="glas"&&talk.finished&&!state.won)
        {
            gameObject.GetComponent<AudioSource>().clip = wrong;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<AudioSource>().clip = picClip;

            if (talk.npcIndex >= 7)
                talk.npcIndex = 5;
            else if (talk.npcIndex > 4)
                talk.npcIndex++;
            else
                talk.npcIndex = 5;
            
            talk.StartCoroutine(talk.StartDialouge());
        }
    }




}
