using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
  //changed when the trigger is hit 
    public GameObject HeatTrigger; 
    //public GameObject particles; 
    public ParticleSystem ps;
    public bool moduleEnabled;
    public GameObject pot;
	public RotationFixtureInteractable dial; 

    public GameObject stovePlacementZone;
    public GameObject moldPlacementZone;
	public AudioSource playStoveSound;

    public AudioSource bombsounds;

    Animation ani;

    void Start(){

        ps.Stop();

        // get animation for pot mixture
        ani = pot.gameObject.transform.GetChild(17).GetComponent<Animation>();

    }

    private void Update()
    {
        // if pot is cooking but is not fully cooked, play coroutine
        if (Global.Instance.isCooking && !Global.Instance.isCooked)
        {
            Coroutine cr = StartCoroutine(Boil(ani));
        }
    }

    // coroutine for boiling
    IEnumerator Boil(Animation ani)
    {
        pot.transform.GetChild(17).gameObject.SetActive(true);
        ani.Play("boiling");
        Debug.Log("Cooking...");
        yield return new WaitForSeconds(30);
        Debug.Log("Cooked.");

        // remove all the ingredients in pot
        for (int i = 0; i < 17; i++)
        {
            pot.transform.GetChild(i).gameObject.SetActive(false);
        }

        // once isCooked is true, the second wall disappears
        Global.Instance.isCooked = true;
        Global.Instance.transform.GetChild(1).gameObject.SetActive(false);

        // once cooked, pot is once again interactable
        pot.gameObject.GetComponent<XRGrabInteractable>().enabled = true;

        // stop sound effects and particles
        playStoveSound.Stop();
        ps.Stop();

        // show where user should place pot
        stovePlacementZone.SetActive(false);
        moldPlacementZone.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {

        // when the dial touches the heat trigger
        if (other.gameObject.CompareTag("dialHand"))
        {
            

			// making the dial hand stop rotating around
		    dial.enabled = false;

            // play sound effects and particles
            playStoveSound.Play();
            ps.Play();

            // set isCooking to true
            Global.Instance.isCooking = true;

            // HeatTrigger.Constraints = RigidbodyConstraints.FreezeAll | ~RigidbodyConstraints.FreezepositionZ;

            // disable interaction for pot
            pot.GetComponent<XRGrabInteractable>().enabled = false;

            // play subtle sounds of explosions in background
            bombsounds.Play();


        }
    } 	

}


