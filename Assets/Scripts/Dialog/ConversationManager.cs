using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ConversationManager : Singleton<ConversationManager > {
    protected ConversationManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    //Is there a converastion going on
    bool talking = false;

    //The current line of text being displayed
    ConversationEntry currentConversationLine;

    //the Canvas Group for the dialog box
    public CanvasGroup dialogBox;

    //the text holder
    public Text textHolder;

    public void StartConversation(Conversation conversation)
    {
        dialogBox = GameObject.Find("DialogBox").GetComponent<CanvasGroup>();        
        textHolder = GameObject.Find("DialogText").GetComponent<Text>();

        //Start displying the supplied conversation
        if (!talking)
        {
            StartCoroutine(DisplayConversation(conversation));
        }
    }

    IEnumerator DisplayConversation(Conversation conversation)
    {
        talking = true;
        foreach (var conversationLine in conversation.ConversationLines)
        {
            currentConversationLine = conversationLine;

            textHolder.text = currentConversationLine.ConversationText;
            
            yield return new WaitForSeconds(3);
        }
        talking = false;
    }

    void OnGUI()
    {
        if (talking)
        {
            dialogBox.alpha = 1;
            dialogBox.blocksRaycasts = true;

        }
        else{
            dialogBox.alpha = 0;
            dialogBox.blocksRaycasts = false;
        }
    }
}

