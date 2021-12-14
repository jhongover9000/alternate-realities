using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterController : MonoBehaviour
{
    public GameObject mainEyeAnchor;
    private float rotationSpeed = 90;

    private void Update()
    {
        // update the position of the holster to follow the main camera
        transform.position = new Vector3(mainEyeAnchor.transform.position.x, mainEyeAnchor.transform.position.y/1.05f, mainEyeAnchor.transform.position.z);
        transform.forward = transform.forward * 1.1f;

        // get difference from target and current rotationx
        var rotationDiff = Mathf.Abs(mainEyeAnchor.transform.eulerAngles.y - transform.eulerAngles.y);
        var finalRotationSpeed = rotationSpeed;

        // tweak rotation speed depending on difference from target
        if(rotationDiff > 60)
        {
            finalRotationSpeed *= 2;
        }
        else if (40 < rotationDiff && rotationDiff <= 60)
        {
            // do nothing to change speed
        }
        else if (20 < rotationDiff && rotationDiff <= 40)
        {
            finalRotationSpeed /= 2;
        }
        else if (0 < rotationDiff && rotationDiff <= 20)
        {
            finalRotationSpeed /= 4;
        }

        // final step size is the speed * time frame time
        var step = finalRotationSpeed * Time.deltaTime;

        // rotate towards desired rotation angle
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, mainEyeAnchor.transform.eulerAngles.y, 0), step);

    }
}
