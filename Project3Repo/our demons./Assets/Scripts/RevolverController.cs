using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class RevolverController : MonoBehaviour, ICanHolster
{
    public static RevolverController Instance;

    public GameObject revolver;

    // is holsterable
    public int SnapPosition { get; set; } = 1;

    public GameObject projectilePrefab;     // prefab of bullet
    public GameObject visual;

    public int bulletCount = 6;

    // firing variables
    float launchForce = 1000.0f;            // speed of bullet
    public Transform launchSpawn;           // spawn of bullet
    public GameObject particleGroup;        // particles
    public AudioSource audioSource;         // sound of revolver
    public AudioClip gunshot;
    public AudioClip empty;
    // firing debugging
    public bool isFiring = false;
    public bool canFire = false;          // prevents user from shooting in certain scenes
    public bool isPicked = false;
    public bool isDropped = false;

    public Recoil RecoilObject;

    // audio on pickup, shooting, etc.
    public AudioClip firstPick;             // "they say this gun can kill anything... I should holster it for now." #supernatural
    public AudioClip dontShoot;             // maybe shooting now isn't a good idea

    // first pickup variables
    public bool firstPickup = true;
    public Transform holsterSpawn;          // spawn of holster (after being picked up)
    public bool isHolstered = false;        // is holstered? (for scene loading)

    // Debug
    //private void Update()
    //{
    //    if (isFiring)
    //    {
    //        Launch();
    //    }

    //    if (isPicked){
    //        PickedUp();
    //    }

    //    if (isDropped)
    //    {
    //        HolsterWeapon();
    //    }

    //}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Detected that singleton RevolverController has already been created. Deleting this instance.");
            //there can be only one!
            Destroy(this.gameObject);
            return;
        }
    }

    public void Launch()
    {
        // only able to fire in certain scenes
        if (XRSceneTransitionManager.Instance.currentScene.name == "Bamboo" || XRSceneTransitionManager.Instance.currentScene.name == "Shrine")
        {
            canFire = true;
        }

        if (canFire)
        {
            isFiring = true;

            if (bulletCount > 0)
            {
                // shoot bullet
                GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(projectile.transform.forward * launchForce);

                // kick back & barrel roll

                // particles
                if (bulletCount == 6)
                {
                    // particles
                    for (int i = 0; i < particleGroup.transform.childCount; i++)
                    {
                        particleGroup.transform.GetChild(i).gameObject.SetActive(true);
                        ParticleSystem effect = particleGroup.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                        effect.Play();
                    }
                }

                for (int i = 0; i < particleGroup.transform.childCount; i++)
                {
                    particleGroup.transform.GetChild(i).gameObject.SetActive(true);
                    ParticleSystem effect = particleGroup.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    effect.Play();
                }

                // sound of firing
                audioSource.clip = gunshot;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                audioSource.Play();

                // get rid of bullet (front)
                GameObject child = visual.transform.GetChild(6 - bulletCount).gameObject;
                child.SetActive(false);
                bulletCount--;
                RecoilObject.recoil += 0.1f;

                Debug.Log(bulletCount);
            }
            else
            {
                // sound of empty gun
                audioSource.clip = empty;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                audioSource.Play();
            }

            isFiring = false;
        }
        // if in a place where you can't shoot, don't allow user to shoot
        else
        {
            PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
            PlayerManager.Instance.audioSource.clip = dontShoot;
            PlayerManager.Instance.audioSource.Play();
        }
    }

    public void PickedUp()
    {
        // if first pickup
        if (firstPickup)
        {
            firstPickup = false;
            // set hasRevolver to true
            PlayerManager.Instance.hasRevolver = true;

            // change spawn location of revolver on drop
            // play audio
            PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
            PlayerManager.Instance.audioSource.clip = firstPick;
            PlayerManager.Instance.audioSource.Play();

        }
        
        //isDropped = false;
        //if (isHolstered)
        //{
        //    // remove from holster if applicable
        //     transform.SetParent(null);
        //    isHolstered = false;
        //}

        PlayerManager.Instance.revolverAimRight.gameObject.SetActive(true);
    }

    public void Dropped()
    {
        isPicked = false;
        isDropped = true;
        // by default, undo the kinematic mode of revolver
        GetComponent<Rigidbody>().isKinematic = false;
        if (isHolstered)
        {
            // set position and rotation of revolver to holster attach
            transform.rotation = PlayerManager.Instance.holsterSpawn.transform.GetChild(0).transform.rotation;
            transform.position = PlayerManager.Instance.holsterSpawn.transform.GetChild(0).transform.position;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            // check to holster weapon if possible
            HolsterWeapon();
            PlayerManager.Instance.revolverAimRight.gameObject.SetActive(false);
        }
        

    }

    // holster weapon (if applicable)
    public void HolsterWeapon()
    {
        var holsters = GameObject.FindGameObjectsWithTag("Holster");
        foreach (var holster in holsters)
        {
            var distanceToHolster = Vector3.Distance(transform.position, holster.transform.position);
            var childrenOfHolster = holster.GetComponentInChildren<ICanHolster>();
            // if distance is close enough
            if (childrenOfHolster == null && distanceToHolster < 0.2f)
            {
                // set position and rotation of revolver to holster attach
                transform.rotation = holster.transform.GetChild(0).transform.rotation;
                transform.position = holster.transform.GetChild(0).transform.position;
                // turn on kinematic and set holster as parent object
                GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<FloorTimeout>().spawnLoc = holster.transform.GetChild(0).transform;
                transform.SetParent(holster.transform);
                isHolstered = true;
            }
            
        }
        
    }
}
