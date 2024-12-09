using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Fungus;

public class LocaleSelector : MonoBehaviour
{
    [SerializeField] int currLocaleID = 0;
    [SerializeField] Flowchart f;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        currLocaleID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(0);

        if (f != null)
        {
            if (currLocaleID == 1) f.ExecuteBlock("ptbr");
        }
    }

    public void ChangeLocale(int add)
    {
        if (active) return;
        currLocaleID += add;
        if (currLocaleID < 0) currLocaleID = 2;
        if (currLocaleID > 2) currLocaleID = 0;
        StartCoroutine(SetLocale(currLocaleID));
    }

    IEnumerator SetLocale(int localeID)
    {
        //ids: en 0, pt-br 1, zh 2
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", currLocaleID);
        active = false;
    }
}
