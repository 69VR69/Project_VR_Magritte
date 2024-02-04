using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceControl : MonoBehaviour
{
    [SerializeField]
    GameObject _object1;
    [SerializeField]
    GameObject _object2;

    [SerializeField] private PrintMessage message;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(_object1.transform.position, _object2.transform.position);
        if (distance < 1 )
        {
            Debug.Log("Distance petite");
            message.ShowMessage();
            return;
        }

    }
}
