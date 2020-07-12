using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoTheater : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Leinwand;
    [SerializeField] private SpriteRenderer Vordergrund;
    [SerializeField] private VideoPlayer video;

    [SerializeField] private craft build;
    [SerializeField] private SpriteChanger yellow;
    [SerializeField] private StoryDialogeManager talk;
    private int hover = 0;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text dialogText;

    private bool playerInRange;
    private bool played;
    private bool firstSeen= true;


    void Start()
    {
        build = build.GetComponent<craft>();
        Leinwand = Leinwand.GetComponent<SpriteRenderer>();
        Vordergrund = Vordergrund.GetComponent<SpriteRenderer>();
        yellow = yellow.GetComponent<SpriteChanger>();
        video = video.GetComponent<VideoPlayer>();
        talk = talk.GetComponent<StoryDialogeManager>();
        played = false;
        dialogText.text = "Möchtest Du das Produktvideo vom Schattentheater anschauen? Dann klicke mit der Maus auf die Leinwand. Du wirst dann in deinen Browser weitergeleitet.";

    }

    void Update()
    {
        if (build.theaterAvailable && talk.finished)
        {
            yellow.isActive = true;

            if (Input.GetKeyDown(KeyCode.Space) && hover == 1)
            {
                video.Play();
                played = true;
                hover = -2;
            }

            else if (!video.isPlaying && played && playerInRange&&video.isPrepared)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (dialogBox.activeSelf)
                        dialogBox.SetActive(false);
                    else
                        dialogBox.SetActive(true);
                }
                else if(firstSeen)
                {
                    dialogBox.SetActive(true);
                    firstSeen = false;
                }
            }
            else
                dialogBox.SetActive(false);
            
            
        }
        else
            yellow.isActive = false;

        
    }

    void OnTriggerEnter2D()
    {
        playerInRange = true;
        if (hover == 0)
            hover = 1;

    }
    void OnTriggerExit2D()
    {
        hover = 0;
        playerInRange = false;
    }

    void OnMouseDown()
    {
        if(build.theaterAvailable && talk.finished)
        {
            Application.OpenURL("https://vimeo.com/436444107");
        }
    }
}
