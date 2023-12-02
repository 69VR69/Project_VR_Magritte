using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class ProfilerToText : MonoBehaviour
{
    public Text display;

    void Start()
    {
        // Affichez les informations du Profiler
        display.text = $"Profiler\n";  // En Mo
        display.text += $"CPU Load: {Profiler.GetTotalReservedMemoryLong() / 1048576f:F2} MB\n";  // En Mo
        display.text += $"GPU Load: {Profiler.GetTotalReservedMemory() / 1048576f:F2} MB";  // En Mo
    }
}