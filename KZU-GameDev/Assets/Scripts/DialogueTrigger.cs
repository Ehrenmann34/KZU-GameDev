using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

public GameObject trash;
public GameObject rose;
public GameObject slot1;
public GameObject slot2;
public GameObject npc;



public static bool roseQuestGoing = false;
public static bool roseQuestFinished = false;
public static bool roseQuestStarted = false;



public static bool muellQuestGoing = false;
public static bool muellQuestFinished = false;
public static bool muellQuestStarted = false;




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
    if(npc.name == "NPC_Phoebe")
        {
            if(roseQuestFinished == false && roseQuestGoing == false && muellQuestGoing == false)
            {
                roseQuestStarted = true;
                FindObjectOfType<DialogueManager>().OpenDialogue(messages1, actors1);

                 // Rose aktivieren
            }

            if(rose != null && roseQuestGoing == true)
            {
                FindObjectOfType<DialogueManager>().OpenDialogue(messages2, actors2);
            }

            if(rose == null && muellQuestGoing == false && slot1.transform.childCount > 0)
            {
                FindObjectOfType<DialogueManager>().OpenDialogue(messages3, actors3);
                // Quest finished true
                // Quest onGoing false
                GameObject.Destroy(slot1.transform.GetChild(0).gameObject);
            }




            if(roseQuestFinished == true && slot1.transform.childCount == 0 || muellQuestGoing == true)

            {

                FindObjectOfType<DialogueManager>().OpenDialogue(messages4, actors4);

            }

        }

            





        if(npc.name == "NPC_Hausmeister")

        {

            if(muellQuestFinished == false && muellQuestGoing == false && roseQuestGoing == false)

            {

                FindObjectOfType<DialogueManager>().OpenDialogue(messages1, actors1);

                muellQuestStarted = true;

                // Trash aktivieren

                // QuestOnGoing true

            }




            if(trash.transform.childCount > 0 && muellQuestGoing == true || (slot1.transform.childCount > 0 && muellQuestGoing == true) || (slot2.transform.childCount > 0 && muellQuestGoing == true))

            {

                FindObjectOfType<DialogueManager>().OpenDialogue(messages2, actors2);

            }




            if(trash.transform.childCount == 0 && muellQuestGoing == true && muellQuestFinished == false && slot1.transform.childCount == 0 && slot2.transform.childCount == 0)

            {

                FindObjectOfType<DialogueManager>().OpenDialogue(messages3, actors3);

                // Quest finished true

                // Quest onGoing false

            }




            if(trash.transform.childCount == 0 && muellQuestGoing == false && muellQuestFinished == true && slot1.transform.childCount == 0 && slot2.transform.childCount == 0 || roseQuestGoing == true)

            {

                FindObjectOfType<DialogueManager>().OpenDialogue(messages4, actors4);

            }

        }

    }




    void Update()

    {

        

        if(roseQuestFinished == false && roseQuestGoing == false && DialogueManager.isActive == true && roseQuestStarted == true && muellQuestGoing == false)

        {

            rose.SetActive(true);

            roseQuestGoing = true;

            

        }

        if(rose == null && roseQuestGoing == true && DialogueManager.isActive == true)

        {

            roseQuestFinished = true;

           roseQuestGoing = false;

        }





        if(muellQuestFinished == false && muellQuestGoing == false && DialogueManager.isActive == true && muellQuestStarted == true && roseQuestGoing == false)

        {

            trash.SetActive(true);

            muellQuestGoing = true;

        }

        if(trash.transform.childCount == 0 && muellQuestGoing == true && slot1.transform.childCount == 0 && slot2.transform.childCount == 0 && DialogueManager.isActive == true)

        {

            muellQuestFinished = true;

            muellQuestGoing = false;

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