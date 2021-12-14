using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Linq;

public static class XRSceneSelector
{
    [MenuItem("XR Scenes/Menu")]
    static void OpenMenu()
    {
        EditorXRSceneUtils.LoadXRScene("Menu");
    }
    [MenuItem("XR Scenes/House")]
    static void OpenHouse()
    {
        EditorXRSceneUtils.LoadXRScene("House");
    }
    [MenuItem("XR Scenes/Memory")]
    static void OpenMemory()
    {
        EditorXRSceneUtils.LoadXRScene("Memory");
    }
    [MenuItem("XR Scenes/Bamboo")]
    static void OpenForest()
    {
        EditorXRSceneUtils.LoadXRScene("Bamboo");
    }
    [MenuItem("XR Scenes/Shrine")]
    static void OpenShrine()
    {
        EditorXRSceneUtils.LoadXRScene("Shrine");
    }

    // Load Scene
    static void LoadXRScene(string scene)
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        Scene xrScene = EditorSceneManager.OpenScene("Assets/Scenes/XR.unity", OpenSceneMode.Single);
        Scene newScene = EditorSceneManager.OpenScene("Assets/Scenes/" + scene + ".unity", OpenSceneMode.Additive);

        //XRSceneTransitionManager.PlaceXRRig(xrScene, newScene);
        PlaceXRRig(xrScene, newScene);
    }

    // Readjust XR Rig
    static public void PlaceXRRig(Scene xrScene, Scene newScene)
    {
        GameObject[] xrObjects = xrScene.GetRootGameObjects();
        GameObject[] newSceneObjects = newScene.GetRootGameObjects();

        GameObject xrRig = xrObjects.First((obj) => { return obj.CompareTag("XR Rig"); });
        GameObject xrRigOrigin = newSceneObjects.First((obj) => { return obj.CompareTag("XR Origin"); });

        if (xrRig && xrRigOrigin)
        {
            xrRig.transform.position = xrRigOrigin.transform.position;
            xrRig.transform.rotation = xrRigOrigin.transform.rotation;
        }
    }
}
