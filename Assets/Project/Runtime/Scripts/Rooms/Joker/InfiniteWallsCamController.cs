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

    [Header("Walls")]
    [SerializeField]
    private GameObject[] _Walls = new GameObject[4];
    private int _CurrentCenterWall = -1;

    [Header("Cameras")]
    [SerializeField]
    private GameObject _Cameras;

    private GameObject _Player;
    private Camera _PlayerCamera;

    private void Start()
    {
        if (_Walls.Length == 0)
        {
            Debug.LogError("No walls found");
            return;
        }

        if (_RightTexture == null || _BackTexture == null || _LeftTexture == null || _BaseTexture == null)
        {
            Debug.LogError("No textures found");
            return;
        }

        if (_Cameras == null)
        {
            Debug.LogError("No cameras found");
            return;
        }
    }

    private void Update()
    {
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
            _PlayerCamera = _Player.GetComponentInChildren<Camera>();
            _Cameras.transform.SetParent(_PlayerCamera.transform);
            _Cameras.transform.localPosition = Vector3.zero;
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
        if (Physics.Raycast(_PlayerCamera.transform.position, _PlayerCamera.transform.forward, out RaycastHit hit, 100))
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
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
        if (_PlayerCamera == null)
            return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(_PlayerCamera.transform.position, _PlayerCamera.transform.forward);
    }
}
