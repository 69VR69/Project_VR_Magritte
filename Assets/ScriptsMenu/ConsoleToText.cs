using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class ConsoleToText : MonoBehaviour
{
    public int maxDisplayLines = 10;
    private List<string> allLogs = new List<string>();
    private List<string> displayedLogs = new List<string>();
    public Text display;

    private void Start()
    {
        // Exemple de message d'erreur
        AddLog("Le jeu a démarré");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    //Personalised message in the console
    public void AddLog(string message)
    {
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        string formattedLog = $"<color=green><{currentTime}></color> {message}";

        allLogs.Add(formattedLog);
        UpdateDisplayedLogs();
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            string formattedLog = $"<color=red><{currentTime}></color> {logString}";

            allLogs.Add(formattedLog);
            UpdateDisplayedLogs();
        }
    }

    void UpdateDisplayedLogs()
    {
        displayedLogs.Clear();
        int startIndex = Mathf.Max(0, allLogs.Count - maxDisplayLines);

        for (int i = startIndex; i < allLogs.Count; i++)
        {
            displayedLogs.Add(allLogs[i]);
        }

        UpdateDisplayText();
    }

    void UpdateDisplayText()
    {
        display.text = string.Join("\n", displayedLogs.ToArray());
    }
}
