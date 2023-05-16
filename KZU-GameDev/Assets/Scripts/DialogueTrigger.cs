using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject rose;
    public GameObject slot1;

    public static bool roseQuestGoing = false;
    public static bool roseQuestFinished = false;

    public Message[] messages1;
    public Actor[] actors1;

    public Message[] messages2;
    public Actor[] actors2;

    public Message[] messages3;
    public Actor[] actors3;

    public Message[] messages4;
    public Actor[] actors4;

    public void StartDialogue()
    {

        if(roseQuestFinished == false && roseQuestGoing == false)
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages1, actors1);
            // Rose aktivieren
            // QuestOnGoing true
        }

        if(rose != null && roseQuestGoing == true)
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages2, actors2);
        }

        if(rose == null && roseQuestGoing == true && slot1.transform.childCount > 0)
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages3, actors3);
            // Quest finished true
            // Quest onGoing false
        }

        if(rose == null && roseQuestFinished == true)
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages4, actors4);    
        }
    }

    void Update()
    {
        if(roseQuestFinished == false && roseQuestGoing == false && DialogueManager.isActive == true)
        {
            rose.SetActive(true);
            roseQuestGoing = true;
        }
        if(rose == null && roseQuestGoing == true && slot1.transform.childCount > 0 && DialogueManager.isActive == true)
        {
            roseQuestFinished = true;
            roseQuestGoing = false;
            GameObject.Destroy(slot1.transform.GetChild(0).gameObject);
        }
    }

}

[System.Serializable]
public class Message 
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
