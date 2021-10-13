using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public Transform spawnLoc;
    public MeshRenderer bucketRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GrabCube"))
        {
            HighlightController hc = other.gameObject.GetComponent<HighlightController>();
            Color cubeColor = hc.getBaseColor();

            bucketRenderer.material.color = cubeColor;

            //chang color of cube to random color and reposition
            hc.SetBaseColor(Random.ColorHSV());

            other.gameObject.transform.position = spawnLoc.position;
        }
    }
}
