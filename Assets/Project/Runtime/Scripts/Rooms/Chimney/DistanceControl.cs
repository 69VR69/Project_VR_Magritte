using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceControl : MonoBehaviour
{
    [SerializeField]
    GameObject _objectlocomotive;
    [SerializeField]
    GameObject _objectbrickboard;
    [SerializeField]
    GameObject _newboard;

    [SerializeField] private PrintMessage message;

    
    void Start()
    {
    }

    /// <summary>
    /// Calcule la distance entre la locomotive et le tableau de briques
    /// </summary>
    void Update()
    {
        var distance = Vector3.Distance(_objectlocomotive.transform.position, _objectbrickboard.transform.position);
        if (distance < 2 )
        {
            Debug.Log("Short distance between the locomotive and the brickboard");
            //message.ShowMessage();
            _newboard.SetActive(true);
            _objectbrickboard.SetActive(false);

            return;
        }

    }
}
