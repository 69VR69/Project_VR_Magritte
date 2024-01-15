using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal SceneManagement SceneManager;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Check if the player is not null
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }
    }

    private void ActivateScene(int sceneId)
    {
        if (_loadedScenes.Count <= 0)
            return;

        // Get The loaded scene
        Scene sceneToActivate = _loadedScenes.Find(scene => scene.buildIndex == sceneId);

        // Activate the scene
        SceneManager.SetActiveScene(sceneToActivate);

        // Set the current scene index
        _currentSceneIndex = sceneToActivate.buildIndex;

        // Get the scene main gameObject
        GameObject sceneMainGameObject = sceneToActivate.GetRootGameObjects().FirstOrDefault();

        // Teleport the player to the spawn point in the sceneMainGameObject
        GameObject tpPoint = sceneMainGameObject.transform.Find(_tagTpPoint).gameObject;
        _player.transform.position = tpPoint.transform.position;

        // Unload the oldest scene if there is more than 2 scenes loaded
        if (_loadedScenes.Count > 2)
        {
            // Get the oldest scene
            Scene sceneToUnload = _loadedScenes.FirstOrDefault();

            // Unload the scene
            SceneManager.UnloadSceneAsync(sceneToUnload);
        }

        // Prepare the following scene if exist
        int nextScene = _scenes.Where(s => s == _currentSceneIndex + 1)?.FirstOrDefault() ?? -1;
        if (nextScene != -1)
            PrepareScene(nextScene);

    }

    private void PrepareScene(int sceneId)
    {
        // Launch the asynchronous loading of the scene
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    private IEnumerator LoadSceneAsync(int sceneId)
    {
        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Additive);

        // Wait until the scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get the scene that was loaded
        Scene scene = SceneManager.GetSceneByBuildIndex(sceneId);
        _loadedScenes.Add(scene);
    }
}
