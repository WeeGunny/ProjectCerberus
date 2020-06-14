using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text npcNameText;
    public Text dialogueText;

    private List<string> conversation;
    private int conversationIndex;

    // Start is called before the first frame update
    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialog(Conversation convo)
    {
        npcNameText.text = convo.npcName;
        conversation = new List<string>(convo.myConversation);
        dialoguePanel.SetActive(true);
        conversationIndex = 0;
        ShowText();
    }

    public void StopDialog()
    {
        dialoguePanel.SetActive(false);
    }

    private void ShowText()
    {
        dialogueText.text = conversation[conversationIndex];
    }

    public void Next()
    {
        if (conversationIndex < conversation.Count - 1)
        {
            conversationIndex += 1;
            ShowText();
        }
    }
}
