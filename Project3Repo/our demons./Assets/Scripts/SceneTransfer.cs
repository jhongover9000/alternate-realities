using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public string toScene = "XR";

    public bool changeLayer = true;

    public int toLayer = 0;

    // caching variables
    int previousLayer;
    string previousScene;

    public void Transfer()
    {
        // if scene is already the desired scene, do nothing
        if (gameObject.scene.name == toScene) return;
         
        // check if object is at root, if not move it to root
        if(transform.parent != null)
        {
            // setparent keeps the locations
            transform.SetParent(null);
        }

        Scene newScene = SceneManager.GetSceneByName(toScene);
        if (newScene.IsValid())
        {
            // cache previous scene
            previousScene = gameObject.scene.name;
            previousLayer = gameObject.layer;
            SceneManager.MoveGameObjectToScene(gameObject, newScene);
            if (changeLayer) gameObject.layer = toLayer;
        }


    }

    // check for the scene amongst the previously loaded scenes (the scene we came from is unloaded)
    public void Return()
    {
        if (previousScene == string.Empty) return; // no previous scene; nothing to do

        Scene prevScene = SceneManager.GetSceneByName(previousScene);

        if (prevScene.IsValid())
        {
            prevScene = SceneManager.GetActiveScene();
        }

        if (changeLayer) gameObject.layer = previousLayer;

        if (gameObject.scene.name == prevScene.name) return; // already at the desired scene

        SceneManager.MoveGameObjectToScene(gameObject, prevScene);
    }
}
