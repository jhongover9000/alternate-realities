using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTabeController : MonoBehaviour
{

    // when the finished bomb lands on the marker, end the simulator.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            int count = 0;
            for(int i = 0; i < other.transform.childCount; i++)
            {
                if (other.transform.GetChild(i).gameObject.activeSelf)
                {
                    count++;
                }
            }
            // if bomb is complete
            if(count == other.transform.childCount)
            {
                other.gameObject.SetActive(false);
            }
            
        }

    }

}
