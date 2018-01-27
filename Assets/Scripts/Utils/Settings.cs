using UnityEngine;

using Language = Utils.Language;

class Settings
{
    private static Settings instance;

    public static Settings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }
    }
    
    public Language CurrentLanguage;

    Settings()
    {
        if (!PlayerPrefs.HasKey("Lang"))
        {
            CurrentLanguage = Language.ENG;
            PlayerPrefs.SetInt("Lang", (int)CurrentLanguage);
        }
        else
        {
            CurrentLanguage = (Language)PlayerPrefs.GetInt("Lang");
        }
    }

    public void ChageLanguage(Language lang)
    {
        CurrentLanguage = lang;
    }
}

