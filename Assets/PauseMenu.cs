using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{

    bool isActive = true;
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")) {
            Debug.Log("esc");
            ShowHidePauseMenu();
        }
    }

    void ShowHidePauseMenu() {
        if (isActive) {
            pauseMenu.SetActive(false);
            isActive = false;
        }
        else {
            pauseMenu.SetActive(true);
            isActive = true;
        }
    }
}
