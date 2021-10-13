using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KinematicController : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Disable Kinematic
    public void kinematicOff()
    {
        rb.isKinematic = false;
    }

    // Enable Kinematic
    public void kinematicOn()
    {
        rb.isKinematic = true;
    }
}
