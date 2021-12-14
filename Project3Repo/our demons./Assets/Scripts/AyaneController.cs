using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AyaneController : MonoBehaviour
{
    private XRController xr;

    public bool isKillable = false;

    private void Start()
    {
        xr = PlayerManager.Instance.rightCont.GetComponent<XRController>();

        isKillable = true; //always kill easter egg
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the ending is about to be triggered, go for it bruh
        if (isKillable)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerManager.Instance.EndingOne();
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                PlayerManager.Instance.EndingTwo();
            }
        }
    }

    public void Killable()
    {
        isKillable = true;
        xr.SendHapticImpulse(0.7f, 1f);
    }

}
