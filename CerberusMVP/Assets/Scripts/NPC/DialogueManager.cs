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
    public TextMeshProUGUI functionButtonText;
    public rbPlayer player;
    public GameObject nextButton,functionButton;

    private List<string> conversation;
    private int conversationIndex;
    public static DialogueManager dm;
    public enum ChatType { shopKeeper, travelGuide,armourer, Default }
    public ChatType chatType = ChatType.Default;
    bool isTyping;
    NPC interactingNPC;

    private void Awake() {
        if (dm == null) {
            dm = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialog(Conversation convo,NPC npcTalking)
    {
        interactingNPC = npcTalking;
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
        functionButton.SetActive(false);
        interactingNPC.DeactivateNPC();
    }

    private void ShowText()
    {
        string sentence = conversation[conversationIndex];
        if (isTyping) {
            StopAllCoroutines();
        }
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);

        }
        isTyping = false;
    }

    public void Next()
    {
        if (conversationIndex < conversation.Count - 1)
        {
            conversationIndex += 1;
            ShowText();
            if (conversationIndex == conversation.Count - 1) {
                nextButton.SetActive(false);
                ShowFunctionButton();
            }
        }
    }


    public void ShowFunctionButton() {

        switch (chatType) {
            case ChatType.shopKeeper:
                functionButtonText.text = "Shop";
                break;
            case ChatType.travelGuide:
                functionButtonText.text = "Travel";
                break;
            case ChatType.armourer:
                functionButtonText.text = "View Weapons";
                break;
            default:
                functionButtonText.text = "Good Bye";
                break;

        }

        functionButton.SetActive(true);

    }

    public void Function() {
        if (chatType == ChatType.shopKeeper) {
            OpenShop();
        }
        if (chatType == ChatType.travelGuide) {
            Travel();
        }
        if (chatType == ChatType.armourer) {
            OpenArmory();
        }
    }
    public void Travel()
    {
        StopDialog();
        if (rbCam.movePlayerCam == false) {
            rbCam.UnlockCam();
        }
        SceneLoader.instance.LoadScene(3);
        
    }
    public void OpenShop() {
        StopDialog();
        ShopUI.shopUI.ShowShop();
    }

    public void OpenArmory() {
        StopDialog();
        Armory.armory.ShowArmory();
    }

   
}
