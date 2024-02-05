using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class RunAwayCube : MonoBehaviour
{
    private GameObject _player; // Reference to the player XR rig

    [SerializeField]
    private float _distance = 5f; // Distance to run away from the player

    [SerializeField]
    private float _delta = 0.01f; // Extra distance to run away from the player

    [SerializeField]
    private float _speed = 5f; // Speed to run away from the player

    private Vector3 _initialDirection; // Initial direction of the cube

    private Vector3 _projectedPlayerPosition; // Projected player position on the initial direction of the cube

    private void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            // Store the initial direction of the cube
            _initialDirection = transform.position - _player.transform.position;
            _initialDirection.y = 0;
        }
        else
        {
            // Rotate the cube to face the player
            transform.LookAt(_player.transform);

            // Project the player position on the initial direction of the cube
            ProjectPlayerPositionOnAxis();

            // Move the cube along the initial direction
            MoveAlongAxis();
        }
    }

    // Project the player position on the initial direction of the cube
    private void ProjectPlayerPositionOnAxis() =>
        _projectedPlayerPosition = Vector3.Project(_player.transform.position, _initialDirection);

    private void MoveAlongAxis()
    {
        // Calculate the cube position depending of the projected player position
        Vector3 distance = _projectedPlayerPosition - transform.position;

        if (distance.magnitude > _distance + _delta)
        {
            // Move towards the player
            Vector3 newPos = distance.normalized * Time.deltaTime * _speed;
            newPos.y = 0;
            transform.position += newPos;
        }
        else if (distance.magnitude < _distance - _delta)
        {
            // Move away from the player
            Vector3 newPos = distance.normalized * Time.deltaTime * _speed;
            newPos.y = 0;
            transform.position -= newPos;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere to show the distance to run away
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distance);

        // Draw a sphere to show the extra distance to run away
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _distance + _delta);

        // Draw a sphere to show the distance to run towards the player
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _distance - _delta);

        // Draw a line to show the direction to run away
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + _initialDirection * _distance);

        // Draw a line to show the projected player position on the initial direction of the cube
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, _projectedPlayerPosition);
    }
}
