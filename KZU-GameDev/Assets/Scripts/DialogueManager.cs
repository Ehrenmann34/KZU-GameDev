using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
   public Image actorImage;
   public TextMeshProUGUI actorName;
   public TextMeshProUGUI messageText;
   public RectTransform backgroundBox;

   Message[] currentMessages;
   Actor[] currentActors;
   int activeMessage = 0;
   public static bool isActive = false;

   public void OpenDialogue(Message[] messages, Actor[] actors)
   {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
   }
   
     void DisplayMessage()
     {
          Message messageToDisplay = currentMessages[activeMessage];
          messageText.text = messageToDisplay.message;

          Actor actorToDisplay = currentActors[messageToDisplay.actorID];
          actorName.text = actorToDisplay.name;
          actorImage.sprite = actorToDisplay.sprite;
     
          AnimateTextColor();

     }

     public void NextMessage()
     {
          activeMessage++;
          if(activeMessage < currentMessages.Length)
          {
               DisplayMessage();
          }
          else
          {
               backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
               isActive = false;
          }
     }

     void AnimateTextColor()
     {
          LeanTween.textAlpha(messageText.rectTransform, 0, 0);
          LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
     }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.anyKeyDown && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)
        && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow)) && isActive == true)
        {
          NextMessage();
        }
    }
}
