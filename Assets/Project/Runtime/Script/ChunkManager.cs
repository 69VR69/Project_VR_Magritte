using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _chunkCountByDirection = 1; // We should have 3 chunks by direction next to the current chunk (the one where the player is)
    [SerializeField] private GameObject _player;

    private List<GameObject> _chunks = new List<GameObject>();
    private int _currentChunkIndex = 0;
    private int _movingMargin = 10;

    private void Start()
    {
        // Create the chunks around the player
        for (int i = -_chunkCountByDirection; i <= _chunkCountByDirection; i++)
        {
            for (int j = -_chunkCountByDirection; j <= _chunkCountByDirection; j++)
            {
                GameObject chunk = Instantiate(_chunkPrefab, new Vector3(i * 10f, 0f, j * 10f), Quaternion.identity);
                _chunks.Add(chunk);
            }
        }
    }

    private void Update()
    {
        // Check if we need to move the chunks depending of the player position and direction (it can be negative if the player is moving backward)
        if (_player.transform.position.x - _chunks[_currentChunkIndex].transform.position.x > _movingMargin)
        {
            MoveChunks(Vector3.right);
        }
        else if (_player.transform.position.x - _chunks[_currentChunkIndex].transform.position.x < -_movingMargin)
        {
            MoveChunks(Vector3.left);
        }
        else if (_player.transform.position.z - _chunks[_currentChunkIndex].transform.position.z > _movingMargin)
        {
            MoveChunks(Vector3.forward);
        }
        else if (_player.transform.position.z - _chunks[_currentChunkIndex].transform.position.z < -_movingMargin)
        {
            MoveChunks(Vector3.back);
        }

    }

    private void MoveChunks(Vector3 direction)
    {
        // Move the chunks in the given direction
        foreach (GameObject chunk in _chunks)
        {
            chunk.transform.position += direction * 10f;
        }

        // Update the current chunk index
        if (direction == Vector3.right)
        {
            _currentChunkIndex += _chunkCountByDirection * 2 + 1;
        }
        else if (direction == Vector3.left)
        {
            _currentChunkIndex -= _chunkCountByDirection * 2 + 1;
        }
        else if (direction == Vector3.forward)
        {
            _currentChunkIndex += 1;
        }
        else if (direction == Vector3.back)
        {
            _currentChunkIndex -= 1;
        }
    }
}
