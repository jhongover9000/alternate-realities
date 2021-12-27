using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter_script1 : MonoBehaviour
{

    //Total Time
    float totalTime = 100.0f;

    // Check animation status
    bool isFighting = false;
    bool isDead = false;

    // Fighter's animation
    Animation ani;


    // Start is called before the first frame update
    void Start()
    {
        // Link animations
        ani = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        // Decrementing time
        totalTime -= Time.deltaTime;
        // Debug.Log(totalTime);

        // only alive for the first 15 seconds (wait 12 seconds fight 3 seconds)
        if (85 < totalTime && totalTime < 88)
        {
            // if fighting, switches between attacks
            if (isFighting && !ani.isPlaying)
            {
                isFighting = !isFighting;
                ani.Play("prepare spear");
            }
            else if (!isFighting && !ani.isPlaying)
            {
                isFighting = !isFighting;
                ani.Play("attack spear");
            }
            
        }
        // dies after 20 seconds
        else if (totalTime < 85 && !isDead)
        {
            ani.Play("die");
            isDead = true;
        }
        
    }
}
