using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "Messages/Message", order = 1)]
public class Message : ScriptableObject
{
    [SerializeField]
    private string Message_pl;
    [SerializeField]
    private string Message_ang;

    public string GetMessage()
    {
        switch (Settings.Instance.CurrentLanguage)
        {
            case Utils.Language.PL:
                return Message_pl;
            case Utils.Language.ENG:
                return Message_ang;
            default:
                return Message_ang;
        }
    }
}
