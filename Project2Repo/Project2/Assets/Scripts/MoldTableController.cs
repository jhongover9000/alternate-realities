using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldTableController : MonoBehaviour
{
    public GameObject bomb;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pot"))
        {
            Debug.Log("pot placed on wiring table.");

            // show molded explosive
            bomb.SetActive(true);

            // show all the assets on the wiring table
            GameObject gm = GameObject.Find("Station 3/Table Assets");
            for(int i = 0; i < gm.transform.childCount; i++)
            {
                gm.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
    }
}
