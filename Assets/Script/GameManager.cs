using Assets.Script;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal SceneManagement SceneManager;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        SceneManager = GetComponent<SceneManagement>();
    }


}
