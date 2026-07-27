using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Fungus;

public class LocaleSelector : MonoBehaviour
{
    [SerializeField] int currLocaleID = 0;
    [SerializeField] Flowchart f;

    int MAX_LOCALE;  //# of non-english locales
    private bool active = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;
        MAX_LOCALE = LocalizationSettings.AvailableLocales.Locales.Count;
        //print(MAX_LOCALE);
        currLocaleID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(0);

        if (f != null)
        {
            //0 = english, 1 = ptbr, 2 = uk, 3 = ru, 4 = zh-TW, 5 = fr
            switch (currLocaleID)
            {
                case 1:
                    f.ExecuteBlock("ptbr");
                    break;
                case 2:
                    f.ExecuteBlock("uk");
                    break;
                case 3:
                    f.ExecuteBlock("ru");
                    break;
                case 4:
                    f.ExecuteBlock("zh-TW");
                    break;
                case 5:
                    f.ExecuteBlock("fr");
                    break;
                case 6:
                    f.ExecuteBlock("pl");
                    break;
                case 7:
                    f.ExecuteBlock("es");
                    break;
                default:
                    break;
            }

        }
    }

    public void ChangeLocale(int add)
    {
        if (active) return;
        currLocaleID += add;
        if (currLocaleID < 0) currLocaleID = MAX_LOCALE;
        if (currLocaleID > MAX_LOCALE - 1) currLocaleID = 0;
        StartCoroutine(SetLocale(currLocaleID));
    }

    IEnumerator SetLocale(int localeID)
    {
        //ids: en 0, pt-br 1, uk 2, ru 3, zh-TW 4, fr 5
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", currLocaleID);
        active = false;
    }
}
