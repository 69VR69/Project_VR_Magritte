using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour
{

    Animator animator;
    bool doorOpen;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Lorsque le joueur ou un objet Interactable s'approche de la porte, celle-ci s'ouvre
    /// </summary>
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("test doors");
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Interactable")
        {

            doorOpen = true;
            DoorControl("Open");
        }

    }
    /// <summary>
    /// Lorsque le joueur ou un objet Interactable s'éloigne de la porte, celle-ci se ferme
    /// </summary>
    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorControl("Close");
        }
    }
    /// <summary>
    /// Contrôle de l'ouverture et de la fermeture de la porte
    /// </summary>
    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
    }

}
