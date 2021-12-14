using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI; 

public class DeliveryTabeController : MonoBehaviour
{

    //public Image fadeTrigger;
    public Image fadeTrigger;

    public AudioSource aud;

    bool isEnded = false;

    private void Start()
    {
        fadeTrigger.canvasRenderer.SetAlpha(0.0f);


    }
    private void Update()
    {
        
        if (isEnded)
        {
            Application.Quit();
        }
    }

    IEnumerator Ending()
    {
        
        yield return new WaitForSeconds(10);
        isEnded = true;

    }


    // when the finished bomb lands on the marker, end the simulator.
    private void OnTriggerEnter(Collider other)
    {

        // fadeTrigger.canvasRenderer.SetAlpha(0.0f);
        // fadeIn();
        if (other.gameObject.CompareTag("Bomb"))
        {
            other.gameObject.SetActive(false);
            aud.Play();

            // start ending
            StartCoroutine(Ending());
            fadeTrigger.CrossFadeAlpha(1, 2, false);

        }


    }

}
