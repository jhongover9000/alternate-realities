using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_script : MonoBehaviour
{
    //Time Variables
    float totalTime = 100.0f;
    float duration = 10.0f;
    float startTime;


    // Start is called before the first frame update
    void Start()
    {
        // Get start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // All runners do is.. run.

        float t = (Time.time - startTime) / duration;
        //Debug.Log(t);
        this.transform.position += this.transform.forward * 0.02f;
    }
}
