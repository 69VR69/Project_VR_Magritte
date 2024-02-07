using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject _EndingScreen;


    [SerializeField]
    private float _EndScreenDuration = 5.0f;
    [SerializeField]
    private GameObject _InitialPosition;

    [SerializeField]
    private bool _TimerStarted = false;
    [SerializeField]
    private bool _ShowEndingScreen = false;
    private GameObject _Player;

    private void Update()
    {
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            if (_Player.transform.position != _InitialPosition.transform.position)
            {
                if (!_TimerStarted)
                {
                    Debug.Log("[TIMER]:Coroutine launch");
                    StartCoroutine(nameof(TimerBeforeEnd));
                }
            }
        }
    }

    private IEnumerator TimerBeforeEnd()
    {
        Debug.Log("[TIMER]:Starting the timer for " + _EndScreenDuration + "s");

        _TimerStarted = true;
        yield return new WaitForSeconds(_EndScreenDuration);

        Debug.Log("[TIMER]:End of the timer");

        // TP back to the main menu
        SceneManager.LoadScene("NewMainMenuScene");
    }

}
