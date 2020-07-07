using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour

{
    public Animator animator;
    public float spd = 6f;
    public Rigidbody2D rb;

    Vector2 mov;

    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Geschwindigkeit", mov.sqrMagnitude); //ist der Speed größer als 0, muss ich ne Aminamtion abspielen
        if (mov.sqrMagnitude != 0)
        {
            animator.SetFloat("Horizontal", mov.x);
            animator.SetFloat("Vertical", mov.y);
        }

        mov.Normalize(); // Sorgt dafür dass der Speed nicht zu hoch ist
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + mov * spd * Time.fixedDeltaTime);
    }

}
