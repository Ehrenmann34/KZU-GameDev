using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;

    public GameObject itemSymbol;





    private void Start()

    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }




    void OnTriggerEnter2D(Collider2D other)

    {

       if (other.CompareTag("Player"))

        {

            bool itemAdded = false;

            for (int i = 0; i < inventory.slots.Length; i++)

            {

                if (inventory.slots[i].transform.childCount == 0)

                {

                    // Item can be added to inventory

                    Instantiate(itemSymbol, inventory.slots[i].transform, false);

                    itemAdded = true;

                    break;

                }

            }

            

            if (itemAdded)

            {

                Destroy(gameObject);

            }

        }

    }

}
