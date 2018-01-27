using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Message List", menuName = "Messages/Message List")]
public class MessageList : ScriptableObject
{
    public List<Message> Messages;

    MessageList()
    {
        Messages = new List<Message>();
    }

    public Message GetMessage()
    {
        if (Messages.Count > 0)
        {
            Message msg = Messages[Random.Range(0, Messages.Count)];
            return msg;
        }

        return null;
    }
}
