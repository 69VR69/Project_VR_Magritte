using System;
using System.Collections.Generic;

using UnityEngine;

public class InfiniteWallsCamController : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField]
    private Material _RightTexture;
    [SerializeField]
    private Material _BackTexture;
    [SerializeField]
    private Material _LeftTexture;
    [SerializeField]
    private Material _BaseTexture;

    [SerializeField]
    private GameObject[] _Walls = new GameObject[4];
    private int _CurrentCenterWall = -1;

    private GameObject _Player;
    private Camera _Camera;

    private void Start()
    {
        if (_Walls.Length == 0)
        {
            Debug.LogError("No walls found");
            return;
        }
    }

    private void Update()
    {
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
            _Camera = _Player.GetComponentInChildren<Camera>();
            Debug.Log("Player found");
        }
        else
        {
            UpdateWallTexture();
        }
    }

    private void UpdateWallTexture()
    {
        // Get the wall in front of the player and the two walls on the sides
        int frontWall = GetWallInFront();
        
        if (frontWall == -1 || _CurrentCenterWall == frontWall)
            return;

        _CurrentCenterWall = frontWall;

        int rightWall = GetRightWall(_CurrentCenterWall);
        int leftWall = GetLeftWall(_CurrentCenterWall);

        // Set the texture of the walls
        _Walls[_CurrentCenterWall].GetComponent<Renderer>().material = _BackTexture;
        _Walls[rightWall].GetComponent<Renderer>().material = _RightTexture;
        _Walls[leftWall].GetComponent<Renderer>().material = _LeftTexture;
        _Walls[(leftWall + 2) % 4].GetComponent<Renderer>().material = _BaseTexture;

        Debug.Log("Front: " + _Walls[_CurrentCenterWall].name + " Right: " + _Walls[rightWall].name + " Left: " + _Walls[leftWall].name);
    }

    private int GetWallInFront()
    {
        // Send a raycast in front of the player to get the wall in front of him
        if (Physics.Raycast(_Camera.transform.position, _Camera.transform.forward, out RaycastHit hit, 100))
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                return Array.IndexOf(_Walls, hit.collider.gameObject);
            }
        }
        return -1;
    }

    private int GetLeftWall(int frontWall)
    {
        return (frontWall + 3) % 4;
    }

    private int GetRightWall(int frontWall)
    {
        return (frontWall + 1) % 4;
    }

    private void OnDrawGizmos()
    {
        if (_Camera == null)
            return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(_Camera.transform.position, _Camera.transform.forward);
    }
}
