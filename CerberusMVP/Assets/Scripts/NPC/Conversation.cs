using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    public string npcName;

    [TextArea(5, 10)]
    public List<string> myConversation = new List<string>();
}
