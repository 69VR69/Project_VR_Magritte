using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ConsoleToText : MonoBehaviour
{
    public int maxDisplayLines = 10; // Nombre maximal de lignes affich�es
    private List<string> allLogs = new List<string>(); // Liste de tous les messages d'erreur
    private List<string> displayedLogs = new List<string>(); // Liste des messages � afficher
    public Text display;

    private void Update()
    {
        Debug.LogError("message d'erreur"); // Exemple de message d'erreur
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
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
