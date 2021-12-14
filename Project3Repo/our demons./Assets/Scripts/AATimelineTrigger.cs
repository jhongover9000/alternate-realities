using UnityEngine;
using UnityEngine.Playables;

public class AATimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;


    //void OnTriggerExit(Collider c)
    //{
    //    if (c.gameObject.tag == "Player")
    //    {
    //        timeline.Stop();
    //    }
    //}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Play();
        }
    }
}