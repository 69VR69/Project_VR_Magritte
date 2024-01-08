using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{

    [SerializeField]
    private InputManager inputManager;


    public Transform controllerTransform;

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if(Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit))
        {

            Component componentPointed = hit.collider.GetComponent<Component>();
            if (componentPointed != null)
            {
                var click = inputManager.IsTrigger;
                if (click)
                {
                    var renderer = componentPointed.GetComponent<Renderer>();
                    renderer.material.color = Color.yellow;
                }
                else
                {
                    var renderer = componentPointed.GetComponent<Renderer>();
                    renderer.material.color = Color.red;
                }
            }
        }
    }
}
