using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Area1Controller : XRSceneController
{ 
    public Transform xrRigOrigin2;
    public XRSocketInteractor keyCardSocket;
    public XRBaseInteractable keyCard;

    //public override void Init()
    //{
    //    // if the player has already visited area 2, the transporter will have the keycard in it
    //    if (PlayerManager.Instance.hasVisitedArea2)
    //    {
    //        keyCardSocket.startingSelectedInteractable = keyCard;
    //    }
    //}

    //public override Transform GetXRRigOrigin()
    //{
    //    return PlayerManager.Instance.hasVisitedArea2 ? xrRigOrigin2 : xrRigOrigin;
    //}
}

