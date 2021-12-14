using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Transform attach;
    public bool isPicked = false;

    //private void Update()
    //{
    //    if (isPicked)
    //    {
    //        LanternPickup();
    //        isPicked = false;
    //    }
    //}

    // essentially picking up lantern, now illuminates your view
    public void LanternPickup()
    {
        PlayerManager.Instance.hasLantern = true;
        //transform.position = PlayerManager.Instance.leftWrist.transform.GetChild(0).transform.position;
        //transform.rotation = PlayerManager.Instance.leftWrist.transform.GetChild(0).transform.rotation;
        //transform.rotation = PlayerManager.Instance.leftWrist.transform.rotation;
        //transform.position = PlayerManager.Instance.leftWrist.transform.position;

        // turn on kinematic and set holster as parent object
        //GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent = PlayerManager.Instance.leftWrist.transform;

        PlayerManager.Instance.lanternLight.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    public void Dropped()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
