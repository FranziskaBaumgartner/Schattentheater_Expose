using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnikMinigameW : MonoBehaviour
{
    public AudioSource K;
    public AudioSource Z;
    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        K.GetComponent<AudioSource>();
        Z.GetComponent<AudioSource>();
    }

   

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("K"))
        {
            K.Play();
            won = true;

        }
        else if(col.gameObject.CompareTag("Z")|| col.gameObject.CompareTag("M"))
        {
            Z.Play();
        }
    }
}
