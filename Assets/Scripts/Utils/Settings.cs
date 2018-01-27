using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public Utils.Language CurrentLanguage;

    Settings()
    {
        CurrentLanguage = Utils.Language.PL;
    }
}

