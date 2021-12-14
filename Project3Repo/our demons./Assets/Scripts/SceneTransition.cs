using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string nextScene;

    public void NextScene()
    {
        XRSceneTransitionManager.Instance.TransitionTo(nextScene);
    }
}
