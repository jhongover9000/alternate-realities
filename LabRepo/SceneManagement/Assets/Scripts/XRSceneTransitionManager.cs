using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

[DisallowMultipleComponent]

public class XRSceneTransitionManager : MonoBehaviour
{
    // create a singleton class for global manipulation
    public static XRSceneTransitionManager Instance;

    // auto property - read only for other classes
    public bool isLoading { get; private set; } = false;

    public string initialScene;
    Scene xrScene;
    Scene currentScene;

    // fade
    public Material transitionMaterial;
    public float transitionSpeed = 1.0f;
    float currentTransitionAmount = 0.0f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Multiple instances of XRSceneTransitionManager.");
            Destroy(this.gameObject);
            return;
        }

        // get xr scene
        xrScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnNewSceneAdded;

        if (!Application.isEditor)
        {
            TransitionScene(initialScene);
        }
    }

    // transition to scene
    public void TransitionScene(string scene)
    {
        if (!isLoading)
        {
            StartCoroutine(Load(scene));
        }
    }

    // adding new scene means setting it as active
    void OnNewSceneAdded(Scene newScene, LoadSceneMode mode)
    {
        if(newScene != xrScene)
        {
            currentScene = newScene;
            SceneManager.SetActiveScene(currentScene);
            PlaceXRRig(xrScene, currentScene);
        }
    }

    

    // load a scene - nested coroutines
    IEnumerator Load(string scene)
    {
        isLoading = true;

        // start fade
        yield return StartCoroutine(Fade(1.0f));

        // transition scene
        yield return StartCoroutine(UnloadCurrentScene());

        // load new scene
        yield return StartCoroutine(LoadNewScene(scene));

        // unfade
        yield return StartCoroutine(Fade(0.0f));

        isLoading = false;

    }

    // unload current scene
    IEnumerator UnloadCurrentScene()
    {
        AsyncOperation unload = SceneManager.UnloadSceneAsync(currentScene);
        while (!unload.isDone)
        {
            yield return null;
        }
    }

    // load new scene
    IEnumerator LoadNewScene(string scene)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return null;
        }
    }

    IEnumerator Fade(float target)
    {
        while(!Mathf.Approximately(currentTransitionAmount, target))
        {
            currentTransitionAmount = Mathf.MoveTowards(currentTransitionAmount, target, transitionSpeed * Time.deltaTime);
            transitionMaterial.SetFloat("_FadeAmount", currentTransitionAmount);
            yield return null;
        }

        // make sure the screen is fully faded
        transitionMaterial.SetFloat("_FadeAmount", target);
    }

    // Readjust XR Rig
    static public void PlaceXRRig(Scene xrScene, Scene newScene)
    {
        GameObject[] xrObjects = xrScene.GetRootGameObjects();
        GameObject[] newSceneObjects = newScene.GetRootGameObjects();

        GameObject xrRig = xrObjects.First((obj) => { return obj.CompareTag("XR Rig"); });
        GameObject xrRigOrigin = newSceneObjects.First((obj) => { return obj.CompareTag("XROrigin"); });

        if (xrRig && xrRigOrigin)
        {
            xrRig.transform.SetPositionAndRotation(xrRigOrigin.transform.position, xrRigOrigin.transform.rotation);
        }
    }

}
