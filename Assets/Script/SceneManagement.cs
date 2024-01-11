using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField]
        private string _tagTpPoint = "InitPosition";
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private List<int> _scenes = new List<int>();

        private int _currentSceneIndex = 0;
        private Dictionary<Scene, GameObject> _loadedScenes = new Dictionary<Scene, GameObject>();
        private Dictionary<int, Coroutine> _loadingScenes = new Dictionary<int, Coroutine>();

        private void Awake()
        {
            // Check if the player is not null
            if (_player == null)
            {
                Debug.LogError("Player is null");
            }
        }

        private void Start()
        {
            // Prepare the first scene
            PrepareScene(_scenes.FirstOrDefault());
        }

        // TEST ONLY
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateScene(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateScene(2);
            }
        }

        public void ChangeSceneTo(int sceneId)
        {
            if (_scenes.Contains(sceneId))
            {
                ActivateScene(sceneId);
            }
            else
            {
                Debug.LogError($"Scene {sceneId} not found");
            }
        }

        private void ActivateScene(int sceneId)
        {
            if (_loadedScenes.Count <= 0)
                return;

            // Get The loaded scene
            var scene = _loadedScenes.FirstOrDefault((scene) => scene.Key.buildIndex == sceneId);
            Scene sceneToActivate = scene.Key;
            GameObject sceneMainGameObject = scene.Value;

            if (sceneToActivate == null || sceneMainGameObject == null)
            {
                Debug.LogError($"Scene {sceneId} or his gameObject not found to be activated");
                return;
            }

            if (sceneToActivate == SceneManager.GetActiveScene())
            {
                Debug.Log($"Scene {sceneToActivate.name} already activated");
                return;
            }

            // Activate the scene
            SceneManager.SetActiveScene(sceneToActivate);
            sceneMainGameObject.SetActive(true);

            Debug.Log($"Scene {sceneToActivate.name} activated");

            int previousSceneId = _currentSceneIndex;

            // Set the current scene index
            _currentSceneIndex = sceneToActivate.buildIndex;

            // Teleport the player to the spawn point in the sceneMainGameObject
            GameObject tpPoint = sceneMainGameObject.transform.Find(_tagTpPoint).gameObject;
            _player.transform.position = tpPoint.transform.position;

            // Deactivate the scene previous scene
            if (previousSceneId > 0)
                DeactivateScene(previousSceneId);

            // Unload the oldest scene if there is more than 2 scenes loaded
            if (_loadedScenes.Count > 2)
            {
                // Get the oldest scene
                Scene sceneToUnload = _loadedScenes.FirstOrDefault().Key;

                // Unload the scene
                SceneManager.UnloadSceneAsync(sceneToUnload);
            }

            // Prepare the following scene if exist
            int nextScene = _scenes.Where(s => s == _currentSceneIndex + 1)?.FirstOrDefault() ?? -1;
            if (nextScene > 0)
                PrepareScene(nextScene);
        }

        private void DeactivateScene(int sceneId)
        {
            if (_loadedScenes.Count <= 0)
                return;

            // Get the previous scene
            var scene = _loadedScenes.FirstOrDefault((scene) => scene.Key.buildIndex == sceneId);
            Scene previousScene = scene.Key;
            GameObject sceneMainGameObject = scene.Value;

            if (previousScene == null || sceneMainGameObject == null)
            {
                Debug.LogError($"Scene {sceneId} or his gameObject not found to be deactivated");
                return;
            }

            // Get the scene main gameObject
            sceneMainGameObject.SetActive(false);

            Debug.Log($"Scene {previousScene.name} deactivated");
        }

        private void PrepareScene(int sceneId)
        {
            if (_loadingScenes.ContainsKey(sceneId) || _loadedScenes.Any(s => s.Key.buildIndex == sceneId))
            {
                return;
            }

            // Launch the asynchronous loading of the scene
            Coroutine c = StartCoroutine(LoadSceneAsync(sceneId));
            _loadingScenes.Add(sceneId, c);
        }

        private IEnumerator LoadSceneAsync(int sceneId)
        {
            Debug.Log($"Loading scene {sceneId}");
            // Load the scene asynchronously
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Additive);

            // Wait until the scene is loaded
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            /* SCENE LOADED */

            // Remove from the loading scenes
            _loadingScenes.Remove(sceneId);
            Debug.Log($"Scene {sceneId} loaded");

            // Get the scene that was loaded
            Scene scene = SceneManager.GetSceneByBuildIndex(sceneId);
            GameObject sceneMainGameObject = scene.GetRootGameObjects().FirstOrDefault();
            sceneMainGameObject.SetActive(false);
            _loadedScenes.Add(scene, sceneMainGameObject);
            Debug.Log($"Scene {scene.name} added to loaded scenes with game object {sceneMainGameObject.name}");
        }
    }
}