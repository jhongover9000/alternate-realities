using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ShakerController : MonoBehaviour
{
    public GameObject particlePrefab;
    public float force = 1.0f;
    public Transform generationLoc;

    // when activated with trigger, shakers will generate particles
    public void generateParticles()
    {
        for(int i = 0; i < 9; i++)
        {
            GameObject particle = GameObject.Instantiate(particlePrefab, generationLoc.position, generationLoc.rotation);
            particle.gameObject.tag = particlePrefab.tag;
            Rigidbody rb = particle.GetComponent<Rigidbody>();
            rb.AddForce(particle.transform.forward * Random.Range(force,1.5f*force));

        }
    }
}

