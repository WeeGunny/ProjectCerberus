using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel, interactUI;
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;
    public rbPlayer player;
    public GameObject nextButton;

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
        interactUI.SetActive(false);
        conversationIndex = 0;
        ShowText();
    }

    public void StopDialog()
    {
        dialoguePanel.SetActive(false);;
    }

    private void ShowText()
    {
        string sentence = conversation[conversationIndex];
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);

        }
    }

    public void Next()
    {
        if (conversationIndex < conversation.Count - 1)
        {
            conversationIndex += 1;
            ShowText();
            if (conversationIndex == conversation.Count - 1) nextButton.SetActive(false);
        }
    }

    public void Travel()
    {
        StopDialog();
        SceneManager.LoadScene("Game");
    }
}
