using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    //public int startDelay;
    //Animator animator;
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        //yield WaitForSeconds(4);
        //animation.Play("bubble");
        //animator = GetComponent<Animator>();
        //StartCoroutine(DelayedAnimation());
        m_Animator = gameObject.GetComponent<Animator>();
    }

    /*IEnumerator DelayedAnimation ()
     {
         yield return new WaitForSeconds(startDelay);
         animator.Play("animation_I_want_to_play");
     }*/

    // Update is called once per frame
    void Update()
    {
      
    }
}
