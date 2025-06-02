using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] int thingsToFind;
    [SerializeField] int thingsFound;

    [SerializeField] TextMeshProUGUI text;
    private bool canContinue = false;

    [SerializeField] float delayAfterFinish;

    public int level;

    bool isTiming = false;

    float timeStamp = 0;

    //[SerializeField] GameObject 

    // Start is called before the first frame update
    void Start()
    {
        //print(LocalizationSettings.SelectedLocale + ", " + LocalizationSettings.AvailableLocales.Locales[0]);

        UpdateItemsFoundText();
    }

    // Update is called once per frame
    void Update()
    {
        if (thingsFound >= thingsToFind)
        {
            //Debug.Log("COMPLETED LEVEL");


            if (!isTiming)
            {
                timeStamp = Time.time;
                isTiming = true;
            }
            if (Time.time > timeStamp + delayAfterFinish && canContinue)
            {
                switch (level)
                {
                    case 1:
                        SceneManager.LoadScene("Two_Before");
                        break;
                    case 2:
                        SceneManager.LoadScene("Three_Before");
                        break;
                    case 3:
                        SceneManager.LoadScene("Final");
                        break;

                }
            }
        }

        UpdateItemsFoundText();
    }

    public void UpdateItemsFoundText()
    {
        string newItemsStr = (thingsToFind - thingsFound).ToString();
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            text.enabled = true;
            text.text = "Restam " + newItemsStr + " itens";
        }
        else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            //ptbrtext.enabled = false;
            text.text = newItemsStr + " things to fix";
        }
        else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[2])
        {   //uk
            text.text = newItemsStr + " зламаних речей";
        }
    }

    public void ThingFound()
    {
        thingsFound++;
        UpdateItemsFoundText();
        canContinue = false;
    }

    public void okToContinue()
    {    //the flowchart calls this so that the last dialogue isn't cut off
         //ew lol why did i java the function name
        canContinue = true;
    }
}
