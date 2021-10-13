using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    bool detonator = false;
    bool redWire = false;
    bool blueWire = false;
    public GameObject deliveryArea;

    // yes it's kinda hardcoded but i mean it works, right?
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("triggered");
        //Debug.Log(collision.gameObject.CompareTag("Detonator"));
        // if detonator is touched against bomb body
        if (!detonator && collision.gameObject.CompareTag("Detonator"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("detonator attached.");
            transform.GetChild(0).gameObject.SetActive(true);
            detonator = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        // if red wire is touched against bomb body
        else if (!redWire && collision.gameObject.CompareTag("Red Wire"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("redwired.");
            transform.GetChild(1).gameObject.SetActive(true);
            redWire = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        // if blue wire is touched against bomb body
        else if (!blueWire && collision.gameObject.CompareTag("Blue Wire"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("bluewired.");
            transform.GetChild(2).gameObject.SetActive(true);
            blueWire = true;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        // if bomb has been completed
        if(detonator && redWire && blueWire)
        {
            // if bomb is assembled, remove final wall
            Global.Instance.transform.GetChild(2).gameObject.SetActive(false);

            // display the "deliver here" box on the delivery table
            deliveryArea.SetActive(true);
            
        }
    }
}
