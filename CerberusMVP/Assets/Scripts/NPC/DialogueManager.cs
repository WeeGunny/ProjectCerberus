using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel, interactUI;
    public Text npcNameText;
    public Text dialogueText;
    public rbPlayer player;

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

        //Disables movement and camera movement
        player.toggleMovement();
        rbCam.ToggleCam();
    }

    public void StopDialog()
    {
        dialoguePanel.SetActive(false);

        //Enables movement again and disables mouse
        player.toggleMovement();
        rbCam.ToggleCam();
    }

    private void ShowText()
    {
        string sentence = conversation[conversationIndex];
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = ;
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
        }
    }

    public void Travel()
    {
        StopDialog();
        SceneManager.LoadScene("Main");
    }
}
