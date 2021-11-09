using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;

public class IngredientController : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    //Transform transform;
    Coroutine cutInterval;

    private int childNum = 0;
    bool isInteractible = true;

    //private void Start()
    //{
    //    transform = gameObject.GetComponent<Transform>();
    //}

    private void OnTriggerExit(Collider other)
    {
        // when knife interacts with ingredient
        if (other.gameObject.CompareTag("Knife"))
        {
            // start coroutine to cut object
            cutInterval = StartCoroutine(cutIngredient(other));
        }
        
    }

    IEnumerator cutIngredient(Collider collider)
    {
        // cut next child inside ingredient by deactivating kinematic
        if (childNum < transform.childCount - 2)
        {
            Debug.Log("cutting");
            Rigidbody childRB = transform.GetChild(childNum).gameObject.AddComponent<Rigidbody>();
            childRB.useGravity = true;
            childRB.isKinematic = false;
            yield return new WaitForSeconds(1);
            childNum++;
        }
        else
        {
            // set as non-interacible layer
            if (isInteractible)
            {
                gameObject.layer = 6;
                isInteractible = false;
            }
        }

    }
}
