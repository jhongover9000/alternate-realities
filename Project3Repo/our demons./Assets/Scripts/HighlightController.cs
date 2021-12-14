using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]

public class HighlightController : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color baseColor;

    public Color highlightColor;
    

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        SetBaseColor(meshRenderer.material.color);

    }

    public Color getBaseColor()
    {
        return baseColor;
    }

    public void SetBaseColor(Color c)
    {
        baseColor = c;
        meshRenderer.material.color = baseColor;
    }

    public void ClearHighlight()
    {
        meshRenderer.material.color = baseColor;
    }

    public void Highlight()
    {
        meshRenderer.material.color = highlightColor;
    }
}
