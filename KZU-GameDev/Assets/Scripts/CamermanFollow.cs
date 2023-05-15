using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamermanFollow : MonoBehaviour

{
    public GameObject Bubbles;
    public GameObject Fynn;

    public Transform transformBubble;
    public Transform transfromFynn;

    void Start()
    {
        if(MainMenu.bubblesSpawn == true)
        {
            Bubbles.SetActive(true);
        }

        if(MainMenu.fynnSpawn == true)
        {
            Fynn.SetActive(true);
        }
    }

    void Update()
    {
        
            if(Bubbles.activeSelf)
            {
                transform.position = transformBubble.position;
            }

            else
            {
                transform.position = transfromFynn.position;
            }
            
        
    }
}
