using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using Unity.XR.PXR;
public class ProfilerToText : MonoBehaviour
{
    public Text display;
    public PXR_FPS fps;

    /// <summary>
    /// Affiche les informations du profiler
    /// </summary>
    void Update()
    {
        display.text = $"Profiler\n";  // En Mo
        display.text += $"CPU Load: {Profiler.GetTotalReservedMemoryLong() / 1048576f:F2} MB\n";  // En Mo
        display.text += $"GPU Load: {Profiler.GetTotalReservedMemory() / 1048576f:F2} MB\n";  // En Mo
        display.text += fps.ShowFps() + "\n";  
    }
    
}