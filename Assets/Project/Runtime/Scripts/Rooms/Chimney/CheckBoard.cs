using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoard : Interactable
{

    [SerializeField]
    DistanceControl distance;
    [SerializeField]
    Texture texture;
    [SerializeField]
    private string _nextRoom;

    // // Update is called once per frame
    // void Update()
    // {
    //     if (distance.CheckDistance())
    //     {
    //         CheckTheBoard();
    //     }
    //     // script pour check si le tableau est posé sur le trpiéd pour la téléportation
    //     // + script pour check si le tableau est bien le bon avant de téléporter (tableau de ju et pas brick)        
    // }

    // void CheckTheBoard()
    // {
    //     Material myMaterials = distance._object1.GetComponent<Renderer>().material;

    //     if(myMaterials == texture){
    //         //teleporter.Run(sender );
    //     }

    // }

    public override void Run(GameObject sender, InputManager inputManager)
    {
        base.Run(sender, inputManager);
        Material myMaterials = distance._object1.GetComponent<Renderer>().material;


        if (distance.CheckDistance() && inputManager.IsTrigger && myMaterials == texture )
        {
            Debug.Log($"Teleporting to {_nextRoom} through the teleporter \"{gameObject.name}\"");

            // Do the teleportation
            GameManager.Instance.SceneManager.ChangeSceneTo(_nextRoom);
        }
    }


}
