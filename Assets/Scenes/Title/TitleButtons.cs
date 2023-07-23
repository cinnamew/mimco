using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class TitleButtons : MonoBehaviour
{
    [SerializeField] Flowchart f;
    public void PlayGame() {
        f.ExecuteBlock("play");
        //SceneManager.LoadScene("Intro");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
