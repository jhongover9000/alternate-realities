using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_script : MonoBehaviour
{
    // Transformation Variables
    public Transform startLoc;
    public Transform endLoc;

    //Time Variables
    float totalTime = 100.0f;
    float duration = 10.0f;
    float startTime;
    float densityDecrease = 0.5f;

    // Dragon's animation
    Animation ani;
    bool isStationary = false;

    // Start is called before the first frame update
    void Start()
    {
        // Link animations
        ani = GetComponent<Animation>();

        // Get start time
        startTime = Time.time;

        // Set fog
        RenderSettings.fogDensity = densityDecrease;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrementing time
        totalTime -= Time.deltaTime;
        //Debug.Log(totalTime);

        // Change fog density over time
        densityDecrease -= Time.deltaTime/25;
        if(densityDecrease <= 0.03)
        {
            densityDecrease = 0.03f;
        }
        // Debug.Log(densityDecrease);
        RenderSettings.fogDensity = densityDecrease;

        // Bring dragon down to ground first 15 seconds
        if (100 > totalTime && totalTime > 90)
        {
            float t = (Time.time - startTime) / duration;
            //Debug.Log(t);
            transform.position = new Vector3(Mathf.SmoothStep(startLoc.position.x, endLoc.position
            .x, t), Mathf.SmoothStep(startLoc.position.y, endLoc.position
            .y, t), Mathf.SmoothStep(startLoc.position.z, endLoc.position
            .z, t));
        }
        else if (91 > totalTime && totalTime >= 86)
        {
            if (!isStationary)
            {
                // land after reaching end spot
                ani.Play("FlyStationaryToLanding");
                isStationary = true;
                
            }
            if (!ani.isPlaying)
            {
                ani.Play("idleBreathe");
            }
             
        }
        
        else if (totalTime < 87)
        {
            ani.Play("spreadFire");
        }



    }
}
