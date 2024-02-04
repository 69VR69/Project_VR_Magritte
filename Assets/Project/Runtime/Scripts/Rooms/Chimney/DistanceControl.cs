using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceControl : MonoBehaviour
{
    [SerializeField]
    public GameObject _object1;
    [SerializeField]
    public GameObject _object2;
    [SerializeField]
    float _distance;

    [SerializeField] private PrintMessage message;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance())
        {
            message.ShowMessage();
            return;
        }
    }

    public bool CheckDistance()
    {
        var distance = Vector3.Distance(_object1.transform.position, _object2.transform.position);
        if (distance < _distance)
        {
            Debug.Log("Distance between the two objects < 1");
            return true;
        }else return false;
    }
}
