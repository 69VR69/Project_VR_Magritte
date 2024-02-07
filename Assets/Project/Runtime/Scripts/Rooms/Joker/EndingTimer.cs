using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject _EndingScreen;

    [SerializeField]
    private float _TimeToWait = 2.0f;

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

                if (_ShowEndingScreen)
                {
                    _ShowEndingScreen = false;
                    StartCoroutine(nameof(EndTheGame));
                }
            }
        }
    }

    private IEnumerator TimerBeforeEnd()
    {
        Debug.Log("[TIMER]:Starting the timer for " + _TimeToWait + "s");

        _TimerStarted = true;
        yield return new WaitForSeconds(_TimeToWait);
        _ShowEndingScreen = true;

        Debug.Log("[TIMER]:End of the timer");
    }

    private IEnumerator EndTheGame()
    {
        // Show the ending screen, then wait for 5 seconds, then TP back the player to the main menu
        _EndingScreen.SetActive(true);
        Debug.Log("[TIMER]:Ending the game");

        // Disable the player's movement
        _Player.GetComponent<PlayerController>().DisableMovement();

        yield return new WaitForSeconds(_EndScreenDuration);

        // TP back to the main menu
        SceneManager.LoadScene("NewMainMenuScene");
    }
}
