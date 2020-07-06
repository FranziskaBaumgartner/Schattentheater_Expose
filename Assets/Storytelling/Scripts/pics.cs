using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
/*
 music plays on hover
 if another is playing this can't be played
 visual que that one is playing
 
 */
public class pics : MonoBehaviour
{

    private bool winning = false;
    private int hover = 0;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (hover == 1)
        {
            hover = -2;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>();
        }
        else if (hover == 0)
        {

            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    private void OnMouseOver()
    {
        if (hover==0)
            hover=1;

    }

    private void OnMouseDown()
    {
        
        if (this.gameObject.tag == "glas")
        {
            this.gameObject.SetActive(false);
            winning = true;
        }
    }
    private void OnMouseExit()
    {
        hover=0;
    }




    }
