using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniGateTrigger : MonoBehaviour
{
    public GameObject firstOni;
    Coroutine coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("spawning first oni.");
            coroutine = StartCoroutine(SpawnOni());
        }
    }

    IEnumerator SpawnOni()
    {
        yield return new WaitForSeconds(2);
        firstOni.SetActive(true);
    }

}
