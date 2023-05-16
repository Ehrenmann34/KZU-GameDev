using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mülleimer : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    
    bool isPlayerInArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = false;
        }
    }

    void Update()
    {
        if (isPlayerInArea && Input.GetKeyDown(KeyCode.Space))
        {
            if (slot1.transform.childCount > 0)
            {
                GameObject childObject = slot1.transform.GetChild(0).gameObject;

                if (!childObject.name.Contains("RoseSymbol"))
                {
                    GameObject.Destroy(childObject);
                }
            }

            if (slot2.transform.childCount > 0)
            {
                GameObject childObject = slot2.transform.GetChild(0).gameObject;

                if (!childObject.name.Contains("RoseSymbol"))
                {
                    GameObject.Destroy(childObject);
                }
            }
        }
    }
}
