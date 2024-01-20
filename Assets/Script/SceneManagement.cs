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
        private List<string> _scenes = new List<string>();

        private string _currentScene = string.Empty;
        private Dictionary<Scene, GameObject> _loadedScenes = new Dictionary<Scene, GameObject>();
        private Dictionary<string, Coroutine> _loadingScenes = new Dictionary<string, Coroutine>();

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
            if (Input.GetKeyDown(KeyCode.Alpha1) || InputManager.Instance.IsBackButton)
            {
                ChangeSceneTo("startroom");
            }
        }

        public void ChangeSceneTo(string sceneName)
        {
            if (_scenes.Contains(sceneName))
            {
                ActivateScene(sceneName);
            }
            else
            {
                Debug.LogError($"Scene \"{sceneName}\" not found");
            }
        }

        private void ActivateScene(string sceneName)
        {
            if (_loadedScenes.Count <= 0)
                return;

            // Get The loaded scene
            var scene = _loadedScenes.FirstOrDefault((scene) => scene.Key.name.ToLowerInvariant() == sceneName.ToLowerInvariant());
            Scene sceneToActivate = scene.Key;
            GameObject sceneMainGameObject = scene.Value;

            if (sceneToActivate == null || sceneMainGameObject == null)
            {
                Debug.LogWarning($"Scene {sceneName} or his gameObject not found to be activated, try again later");
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

            string previousSceneName = _currentScene;

            // Set the current scene index
            _currentScene = sceneName;

            // Teleport the player to the spawn point in the sceneMainGameObject
            GameObject tpPoint = sceneMainGameObject.transform.Find(_tagTpPoint).gameObject;
            _player.transform.position = tpPoint.transform.position;

            // Deactivate the scene previous scene
            if (!string.IsNullOrWhiteSpace(previousSceneName))
                DeactivateScene(previousSceneName);

            // Unload the oldest scene if there is more than 2 scenes loaded
            if (_loadedScenes.Count > 2)
            {
                // Get the oldest scene
                Scene sceneToUnload = _loadedScenes.FirstOrDefault().Key;

                // Unload the scene
                SceneManager.UnloadSceneAsync(sceneToUnload);
            }

            // Prepare the following scene in scene list
            int currentSceneIndex = _scenes.IndexOf(sceneName);
            string nextScene = _scenes.ElementAtOrDefault(currentSceneIndex + 1);
            if (!string.IsNullOrWhiteSpace(nextScene))
                PrepareScene(nextScene);
        }

        private void DeactivateScene(string sceneName)
        {
            if (_loadedScenes.Count <= 0)
                return;

            // Get the previous scene
            var scene = _loadedScenes.FirstOrDefault((scene) => scene.Key.name.ToLowerInvariant() == sceneName.ToLowerInvariant());
            Scene previousScene = scene.Key;
            GameObject sceneMainGameObject = scene.Value;

            if (previousScene == null || sceneMainGameObject == null)
            {
                Debug.LogWarning($"Scene \"{sceneName}\" or his gameObject not found to be deactivated");
                return;
            }

            // Get the scene main gameObject
            sceneMainGameObject.SetActive(false);

            Debug.Log($"Scene \"{previousScene.name}\" deactivated");
        }

        private void PrepareScene(string sceneName)
        {
            if (_loadingScenes.ContainsKey(sceneName) || _loadedScenes.Any(s => s.Key.name.ToLowerInvariant() == sceneName.ToLowerInvariant()))
            {
                return;
            }

            // Launch the asynchronous loading of the scene
            Coroutine c = StartCoroutine(LoadSceneAsync(sceneName));
            _loadingScenes.Add(sceneName, c);
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Debug.Log($"Loading scene \"{sceneName}\"");
            // Load the scene asynchronously
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait until the scene is loaded
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            /* SCENE LOADED */

            // Remove from the loading scenes
            _loadingScenes.Remove(sceneName);
            Debug.Log($"Scene \"{sceneName}\" loaded");

            // Get the scene that was loaded
            Scene scene = SceneManager.GetSceneByName(sceneName);
            GameObject sceneMainGameObject = scene.GetRootGameObjects().FirstOrDefault();
            sceneMainGameObject.SetActive(false);
            _loadedScenes.Add(scene, sceneMainGameObject);
            Debug.Log($"Scene \"{scene.name}\" added to loaded scenes with game object {sceneMainGameObject.name}");
        }
    }
}