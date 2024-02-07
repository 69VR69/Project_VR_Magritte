using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Outliner : MonoBehaviour
{
    Coroutine outlineActivated = null;
    Renderer Renderer;
    private void Start()
    {
        Renderer = GetComponent<Renderer>();
    }

    public void ActiveOutline()
    {
        if (outlineActivated != null || Renderer == null)
            return;

        outlineActivated = StartCoroutine(nameof(Outline));
    }

    private IEnumerator Outline()
    {
        Renderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Renderer.enabled = false;
    }
}
