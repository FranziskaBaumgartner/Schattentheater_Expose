using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class TechnikMinigameBS : MonoBehaviour
{
    private bool hover = false;

    public GameObject child;
    public Transform parent;
    public TechnikMinigameW kamera;
    public StoryDialogeManager dialouge;
    public GameObject inventory;
    public GameObject guard;
    [SerializeField] private SpriteChanger yellow;

    void Start()
    {
        kamera = kamera.GetComponent<TechnikMinigameW>();
        dialouge = dialouge.GetComponent<StoryDialogeManager>();
        yellow = yellow.GetComponent<SpriteChanger>();
    }
    
    void Update()
    {
        if(dialouge.finished &&!kamera.won)
            yellow.isActive = true;
        else
            yellow.isActive = false;

        if (Input.GetKeyDown(KeyCode.Space) && !kamera.won && dialouge.finished)
        {
            if (hover) 
                child.transform.SetParent(parent);
            
            else if (parent.transform.childCount==1)
                if(parent.transform.GetChild(0).CompareTag(this.gameObject.tag))
                    parent.transform.DetachChildren();
                      
            if(parent.transform.childCount>1)
            {
                parent.transform.DetachChildren();
                child.transform.SetParent(parent);
            }
        }
        if (kamera.won&&!inventory.activeSelf&&guard.activeSelf)
        {
            parent.transform.DetachChildren();
            dialouge.npcIndex = 4;
            dialouge.StartCoroutine(dialouge.StartDialouge());
            inventory.SetActive(true);
        }

    }

    

   
    void OnTriggerStay2D(Collider2D col)
    {
        hover = true;
    }
  
    private void OnTriggerExit2D(Collider2D other)
    {
        hover = false;

    }
}
