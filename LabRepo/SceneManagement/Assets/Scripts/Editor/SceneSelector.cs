using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Linq;

public class SceneSelector
{
	// Lobby
	[MenuItem("Scenes/Lobby")]

	static void OpenLobby()
	{
		Load("Lobby");
	}

	// Green Place
	[MenuItem("Scenes/Green Place")]

	static void OpenGreenPlace()
	{
		Load("GreenPlace");
	}

	// Red Place
	[MenuItem("Scenes/Red Place")]

	static void OpenRedPlace()
	{
		Load("RedPlace");
	}

	// Load Scene
	static void Load(string scene)
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
		GameObject xrRigOrigin = newSceneObjects.First((obj) => { return obj.CompareTag("XROrigin"); });

		if (xrRig && xrRigOrigin)
		{
			xrRig.transform.position = xrRigOrigin.transform.position;
			xrRig.transform.rotation = xrRigOrigin.transform.rotation;
		}
	}

}
