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
        
        DontDestroyOnLoad(transform.gameObject);
        AddLog("Affichage de la console");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    /// <summary>
    /// Add a log to start to the console
    /// </summary>
    public void AddLog(string message)
    {
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        string formattedLog = $"<color=green><{currentTime}></color> {message}";

        allLogs.Add(formattedLog);
        UpdateDisplayedLogs();
    }

    /// <summary>
    /// Handle the log message and add it to the console
    /// </summary>
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

    /// <summary>
    /// Update the displayed logs
    /// </summary>
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

    /// <summary>
    /// Update the display text
    /// </summary>
    void UpdateDisplayText()
    {
        display.text = string.Join("\n", displayedLogs.ToArray());
    }
}
