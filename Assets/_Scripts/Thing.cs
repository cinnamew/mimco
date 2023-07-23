using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Thing : MonoBehaviour
{
    LevelManagerScript levelManagerScript;
    bool isMouseOn = false;

    bool isFound = false;
    [SerializeField] Sprite foundSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject fixParticlePrefab;

    AudioSource audioSource;
    [SerializeField] AudioClip sfx;
    [Range(0.0f, 1f)] [SerializeField] float volume;

    [SerializeField] int summonedDialog;

    Flowchart flowchart;



    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManagerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        flowchart = FindObjectOfType<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMouseOn);
    }
    private void OnMouseEnter()
    {
        isMouseOn = true;
    }
    private void OnMouseExit()
    {
        isMouseOn = false;
    }
    private void OnMouseDown()
    {
        if (isMouseOn)
        {
            if (!isFound)
            {
                OnFound();
            }
        }
    }

    private void OnFound()
    {
        audioSource.PlayOneShot(sfx, volume);
        Vector2 clickPos = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Instantiate(fixParticlePrefab, clickPos, Quaternion.identity);
        levelManagerScript.ThingFound();
        isFound = true;
        spriteRenderer.sprite = foundSprite;
        if (summonedDialog > 0)
        {
            switch(summonedDialog)
            {
                case 1:
                    flowchart.ExecuteBlock("tilted painting");
                    break;
                case 2:
                    flowchart.ExecuteBlock("broken glass at front");
                    break;
                case 3:
                    flowchart.ExecuteBlock("broken drawers at back");
                    break;
                case 4:
                    flowchart.ExecuteBlock("glass on floor");
                    break;
                case 5:
                    flowchart.ExecuteBlock("broken window");
                    break;
                case 6:
                    flowchart.ExecuteBlock("bedsheets");
                    break;
                case 7:
                    flowchart.ExecuteBlock("cracked window");
                    break;
                case 8:
                    flowchart.ExecuteBlock("knocked over cup");
                    break;
                case 9:
                    flowchart.ExecuteBlock("pillow on floor");
                    break;
                case 10:
                    flowchart.ExecuteBlock("broken drawer handle");
                    break;
                case 11:
                    flowchart.ExecuteBlock("phone");
                    break;
                case 12:
                    flowchart.ExecuteBlock("tv");
                    break;
                case 13:
                    flowchart.ExecuteBlock("lampshade");
                    break;
                case 14:
                    flowchart.ExecuteBlock("blood");
                    break;
                case 15:
                    flowchart.ExecuteBlock("cobweb");
                    break;
                case 16:
                    flowchart.ExecuteBlock("pillow in corner");
                    break;
                case 17:
                    flowchart.ExecuteBlock("pile of clothes");
                    break;
                case 18:
                    flowchart.ExecuteBlock("blood on bed");
                    break;
                case 19:
                    flowchart.ExecuteBlock("blanket messy");
                    break;
                case 20:
                    flowchart.ExecuteBlock("bloodstain");
                    break;
                case 21:
                    flowchart.ExecuteBlock("bloodstain");
                    break;

                    
            }
            
        }
    }
}
