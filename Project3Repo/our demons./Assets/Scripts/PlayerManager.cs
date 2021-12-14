using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;


[ExecuteInEditMode]

public class PlayerManager : MonoBehaviour
{
    // singleton for player
    public static PlayerManager Instance;

    // XR Rig
    public GameObject xrRig;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftCont;
    public GameObject rightCont;
    public GameObject leftWrist;
    public GameObject rightWrist;

    public GameObject revolverAimRight;
    public GameObject revolverAimLeft;

    // Load Box Group
    public GameObject loadScreen;
    public GameObject endingTitle;

    // Player Objects
    public AudioSource audioSource;
    public GameObject lantern;
    public Light lanternLight;
    public GameObject revolver;
    public GameObject mainHolster;
    public GameObject holster;
    public GameObject holsterSpawn;

    // ending
    public AudioClip laughingEnd;
    public AudioClip onShotClip;   // saying sorry after shooting
    bool hasEnded;

    public bool hasRevolver = false;
    public bool hasLantern = false;

    public bool checkScene = false;

    Scene xrScene;

    Coroutine coroutine;
    //AudioClip clip;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            xrScene = SceneManager.GetActiveScene();
        }
        else
        {
            Debug.LogError("too many player managers.");
            Destroy(this.gameObject);
            return;
        }
    }

    private void Update()
    {
        if (checkScene)
        {
            CheckScene();
            checkScene = false;
        }

        if (hasEnded)
        {
            Debug.Log("Quitting.");
            Application.Quit();
        }
    }

    // cleanup on destroy
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    // check scene to see what needs to be loaded and what doesn't
    public void CheckScene()
    {
        Debug.Log(XRSceneTransitionManager.Instance.currentScene.name);

        PlayerManager.Instance.xrRig.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 2;

        // activate ray if in first scene
        if (XRSceneTransitionManager.Instance.currentScene.name == "Menu")
        {
            lantern.SetActive(false);
            revolver.SetActive(false);
        }
        else
        {
            // deactivate rays
            revolverAimRight.SetActive(false);
            revolverAimLeft.SetActive(false);
            if (XRSceneTransitionManager.Instance.currentScene.name == "House")
            {
                lantern.SetActive(true);
            }
            else
            {
                lantern.SetActive(false);
            }
            revolver.SetActive(true);
        }

        if (XRSceneTransitionManager.Instance.currentScene.name == "Bamboo" || XRSceneTransitionManager.Instance.currentScene.name == "Shrine")
        {
            // if revolver is not holstered (was dropped somewhere in prev scene), holster it
            if (!RevolverController.Instance.isHolstered)
            {
                revolver.transform.position = holster.transform.position;
                RevolverController.Instance.HolsterWeapon();
            }
            if (hasLantern)
            {
                lanternLight.gameObject.SetActive(true);
                lantern.gameObject.SetActive(false);
            }

            PlayerManager.Instance.xrRig.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 1;
        }
        //if (XRSceneTransitionManager.Instance.currentScene.name == "Shrine")
        //{
            

        //}

        
    }

    public void WaitToSpeak(AudioClip clip)
    {
        coroutine = StartCoroutine(WaitForDialogue(clip));
    }

    // wait till audio is finished if it's still playing
    IEnumerator WaitForDialogue(AudioClip clip)
    {
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(clip.length / 2);
        }
        
    }

    public void ShowLoadScreen()
    {
        for(int i = 0; i < loadScreen.transform.childCount; i++)
        {
            loadScreen.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void RemoveLoadScreen()
    {
        for (int i = 0; i < loadScreen.transform.childCount; i++)
        {
            loadScreen.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // endings
    public void EndingOne()
    {
        coroutine = StartCoroutine(PlayEndClip(laughingEnd));
    }
    public void EndingTwo()
    {
        coroutine = StartCoroutine(PlayEndClip(onShotClip));
    }

    IEnumerator PlayEndClip(AudioClip audioClip)
    {
        // show black box and remove current scene
        PlayerManager.Instance.ShowLoadScreen();
        XRSceneTransitionManager.Instance.RemoveScene();
        PlayerManager.Instance.rightHand.SetActive(false);
        PlayerManager.Instance.leftHand.SetActive(false);
        PlayerManager.Instance.mainHolster.SetActive(false);
        PlayerManager.Instance.xrRig.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 0;

        // start audio of ending
        PlayerManager.Instance.WaitToSpeak(PlayerManager.Instance.audioSource.clip);
        PlayerManager.Instance.audioSource.clip = audioClip;
        PlayerManager.Instance.audioSource.Play();
        yield return new WaitForSeconds(5);

        // ending title
        PlayerManager.Instance.endingTitle.SetActive(true);
        yield return new WaitForSeconds(10);
        hasEnded = true;
    }


}
