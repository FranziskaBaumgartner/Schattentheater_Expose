using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//funktioniert nicht
public class SoundTimer : MonoBehaviour
{
    public float time = 30f; //30 seconds for you
 
    public void Update()
    {
        if (time > 0) {
            time -= Time.deltaTime;
         }
        else {
            Debug.Log("Play Audio Here -- Timer Over!!");
            GetComponent<AudioSource>().Play();
         }
    }

}

