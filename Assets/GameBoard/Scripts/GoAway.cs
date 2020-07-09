using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAway : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;
  

    // Update is called once per frame
    void Update()
    {
        if (first.gameObject.activeSelf && second.gameObject.activeSelf && third.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
}
