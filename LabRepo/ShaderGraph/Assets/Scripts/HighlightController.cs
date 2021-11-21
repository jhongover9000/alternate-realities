using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float highlightSpeed = 8.0f;

    Material highlightMaterial;
    float currentHighlightAmount = 0.0f;
    bool highlightEnabled = true;

    Coroutine highlightCoroutine;

    private void Awake()
    {
        highlightMaterial = meshRenderer.material;
    }

    public void StartHighlight()
    {
        if (!highlightEnabled)
        {
            return;
        }

        if (highlightCoroutine != null)
        {
            // stop coroutine and go to 1 (highlight)
            StopCoroutine(highlightCoroutine);
            
        }
        if (enabled)
        {
            highlightCoroutine = StartCoroutine(Highlight(1.0f));
        }
    }

    public void StopHighlight()
    {
        

        if (highlightCoroutine != null)
        {
            // stop coroutine and go back to 0
            StopCoroutine(highlightCoroutine);
            //highlightCoroutine = StartCoroutine(Highlight(0.0f));
        }

        if (enabled)
        {
            highlightCoroutine = StartCoroutine(Highlight(0.0f));
        }
    }

    IEnumerator Highlight(float target)
    {
        while (!Mathf.Approximately(currentHighlightAmount, target) )
        {
            // move the highlight number towards target
            currentHighlightAmount = Mathf.MoveTowards(currentHighlightAmount, target, highlightSpeed * Time.deltaTime);
            highlightMaterial.SetFloat("_GlowAmount", currentHighlightAmount);

            yield return null;
        }
    }

    public void EnableHighlight()
    {
        highlightEnabled = true;
    }

    public void DisableHighlight()
    {
        highlightEnabled = false;
    }
}
