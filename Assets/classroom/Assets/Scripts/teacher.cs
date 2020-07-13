using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacher : MonoBehaviour
{
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying)
        {
            //Debug.Log("stop teacher");
            gameObject.GetComponent<AudioSource>().Pause(); 

        }
        else
        {
            //Debug.Log("teacher is talking...");

        }
            
    }
}
