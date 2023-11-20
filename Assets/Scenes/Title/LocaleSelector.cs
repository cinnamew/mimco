using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    [SerializeField] int currLocaleID = 0;
    private bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeLocale(int add) {
        if(active) return;
        currLocaleID += add;
        if(currLocaleID < 0) currLocaleID = 1;
        if(currLocaleID > 1) currLocaleID = 0;
        StartCoroutine(SetLocale(currLocaleID));
    }

    IEnumerator SetLocale(int localeID) {
        //ids: en 0, pt-br 1
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        active = false;
    }
}
