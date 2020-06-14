using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
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
        conversationIndex = 0;
        ShowText();

        //Disables movement and camera movement
        player.enabled = false;
        rbCam.movePlayerCam = false;
    }

    public void StopDialog()
    {
        dialoguePanel.SetActive(false);

        //Enables movement again and disables mouse
        player.enabled = true;
        rbCam.movePlayerCam = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
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

    public void Travel()
    {
        StopDialog();
        SceneManager.LoadScene("Main");
    }
}
