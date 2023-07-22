using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    LevelManagerScript levelManagerScript;
    bool isMouseOn = false;
    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = FindObjectOfType<LevelManagerScript>();
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
            levelManagerScript.thingsFound++;
            Destroy(gameObject);
        }
    }
}
