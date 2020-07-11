using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class lernKind : MonoBehaviour
{
    private bool hover = false;

    public GameObject child;
    public Transform parent;
    public lernKasten kasten;
    public StoryDialogeManager dialouge;
    public GameObject inventory;
    public GameObject guard;

    [SerializeField] private SpriteChanger yellow;

    void Start()
    {
        kasten = kasten.GetComponent<lernKasten>();
        dialouge = dialouge.GetComponent<StoryDialogeManager>();
        yellow = yellow.GetComponent<SpriteChanger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !kasten.won && dialouge.finished)
        {
            yellow.isActive = true;
            if (hover)
                child.transform.SetParent(parent);

            else if (parent.transform.childCount==1)
                if (parent.transform.GetChild(0).CompareTag(this.gameObject.tag))
                    parent.transform.DetachChildren();

            
        }
        if (kasten.won && !inventory.activeSelf&&guard.activeSelf)
        {
            
            parent.transform.DetachChildren();
            dialouge.npcIndex = 4;
            dialouge.StartCoroutine(dialouge.StartDialouge());
            inventory.SetActive(true);
            yellow.isActive = false;
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
