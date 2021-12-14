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
    private int childCount;

    private void Start()
    {
        childCount = transform.childCount;
    }

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
        if (childNum < childCount-2)
        {
            Debug.Log("cutting");
            Rigidbody childRB;
            // because each new first child is the child that we're trying to remove
            childRB = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();

            // add gravity and turn off kinematic
            childRB.useGravity = true;
            childRB.isKinematic = false;
            // note: this means that the next child to be removed will be the FIRST child
            yield return new WaitForSeconds(0.3f);
            // removes the parent link between child and parent and allows each piece to move individually
            transform.GetChild(0).parent = null;
            childNum++;
        }
        else {
            // get rid of parent object after all pieces have been cut
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}
