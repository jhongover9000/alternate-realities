using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEditor.SceneManagement;

public static class EditorXRSceneUtils
{
    // Load Scene
    public static void LoadXRScene(string scene)
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        Scene xrScene = EditorSceneManager.OpenScene("Assets/Scenes/XR.unity", OpenSceneMode.Single);
        Scene newScene = EditorSceneManager.OpenScene("Assets/Scenes/" + scene + ".unity", OpenSceneMode.Additive);

        //XRSceneTransitionManager.PlaceXRRig(xrScene, newScene);
        PlaceXRRig(xrScene, newScene);
    }

    // Readjust XR Rig
    public static void PlaceXRRig(Scene xrScene, Scene newScene)
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
