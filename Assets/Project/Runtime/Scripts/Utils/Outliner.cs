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
        Renderer.enabled = true;
        outlineActivated = StartCoroutine(nameof(Outline));
    }

    private IEnumerator Outline()
    {
        yield return new WaitForSeconds(0.5f);
        Renderer.enabled = false;
    }
}
