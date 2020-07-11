using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]  private SpriteRenderer self;
    [SerializeField]  private Sprite active;
    [SerializeField] private Sprite inactive;
    public bool isActive;


    void Start()
    {
        self = self.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (isActive)
            self.sprite = active;
        else if (!isActive)
            self.sprite = inactive;
    }


}
