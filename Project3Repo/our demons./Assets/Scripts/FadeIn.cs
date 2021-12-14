using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FadeIn : MonoBehaviour
{

    public Image fadeTrigger;

    // Start is called before the first frame update

    void Start()
    {
        fadeTrigger.canvasRenderer.SetAlpha(0.0f);
        fadeIn();


    }


    // Update is called once per frame
    void fadeIn()
    {
        fadeTrigger.CrossFadeAlpha(1, 2, false);
    }

}
