using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWallsTeleporter : MonoBehaviour
{
    [SerializeField]
    private Transform _OpositeWallTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 tpPosition = _OpositeWallTransform.position;

            if( tpPosition.z > 0)
            {
                tpPosition.z -= 1;
            }
            else
            {
                tpPosition.z += 1;
            }

            if (tpPosition.x > 0)
            {
                tpPosition.x -= 1;
            }
            else
            {
                tpPosition.x += 1;
            }

            Debug.Log("Teleporting to: " + tpPosition);
            other.gameObject.transform.position = tpPosition;
        }
    }
}
