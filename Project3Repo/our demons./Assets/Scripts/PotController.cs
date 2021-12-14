using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PotController : MonoBehaviour
{
    int ingredientsAdded = 0;
    int razzleCount = 0;
    int dazzleCount = 0;
    public GameObject stovePlacementZone;
    public GameObject moldPlacementZone;

    private void Start()
    {
        // you need to put in all the ingredients before you can interact with the pot
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("triggered");
        // pour cut ingredients into pot, if they are cut (not part of ingredient parent object)
        if (collision.gameObject.CompareTag("Ingredient") && collision.gameObject.transform.parent == null)
        {
            
            // deactivate ingredient
            collision.gameObject.SetActive(false);
            // if less than 4 ingredients added, increase the number of ingredients in pot
            if (ingredientsAdded < 4)
            {
                transform.GetChild(ingredientsAdded).gameObject.SetActive(true);
                Debug.Log("Ingredient added.");
                ingredientsAdded++;
            }
            //if 4 or more ingredients are added
            else if (ingredientsAdded >= 4 && !Global.Instance.ingredientsAdded)
            {
                Debug.Log("All ingredients added.");
                Global.Instance.ingredientsAdded = true;
            }

            // destroy ingredient
            //Destroy(collision.gameObject);
        }
        // razzle dazzle
        else if (collision.gameObject.CompareTag("Razzle"))
        {
            
            // deactivate particle
            collision.gameObject.SetActive(false);
            Debug.Log(Global.Instance.ingredientsAdded);
            // if less than 6 particles added AFTER ingredients added, increase the number of ingredients in pot
            if (Global.Instance.ingredientsAdded &&  razzleCount < 6)
            {
                Debug.Log("Razzle");
                transform.GetChild(4 + razzleCount).gameObject.SetActive(true);
                razzleCount+=1;
            }
            else if (razzleCount >= 6)
            {
                Debug.Log("Razzled.");
                
                // if razzle (accompanying set) has also hit 6, razzle dazzled, baby
                if (dazzleCount >= 6)
                {
                    Debug.Log("Razzle dazzled.");
                    Global.Instance.razzleDazzled = true;
                }

            }

            // destroy particle
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Dazzle"))
        {
            
            // deactivate particle
            collision.gameObject.SetActive(false);
            Debug.Log(dazzleCount);
            // if less than 6 particles added AFTER ingredients added, increase the number of ingredients in pot
            if (Global.Instance.ingredientsAdded && dazzleCount < 6)
            {
                Debug.Log("Dazzle");
                transform.GetChild(10 + dazzleCount).gameObject.SetActive(true);
                dazzleCount++;
                
            }
            else if (dazzleCount >= 6)
            {
                Debug.Log("Dazzled.");
                // if razzle (accompanying set) has also hit 6, razzle dazzled, baby
                if (razzleCount >= 6)
                {
                    Debug.Log("Razzle dazzled.");
                    Global.Instance.razzleDazzled = true;
                }

            }

            // destroy particle
            //Destroy(collision.gameObject);
        }
        // mixing
        else if (collision.gameObject.CompareTag("Spoon"))
        {

            if (Global.Instance.razzleDazzled && !Global.Instance.isStirred)
            {
                Debug.Log("Stirred.");
                transform.GetChild(16).gameObject.SetActive(true);

                // once stirred, first wall disappears and the stove placement zone appears
                Global.Instance.isStirred = true;
                Global.Instance.transform.GetChild(0).gameObject.SetActive(false);
                stovePlacementZone.SetActive(true);

                // make pot interactable once stirred
                gameObject.GetComponent<XRGrabInteractable>().enabled = true;
            }

        }
        // place onto mold table
        else if (collision.gameObject.CompareTag("Mold Table"))
        {
            // toggle isPlaced
            Global.Instance.isPlaced = true;
            // empty pot
            for (int i = 0; i < 19; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            // pot is no longer interactable once placed on mold table
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            
        }

    }
}
