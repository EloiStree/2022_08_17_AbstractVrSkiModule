using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wanted to do a tool that collect plenty of point that try to guess what is the curve. But to complicated for nothing. KISS
/// </summary>
public class SkiFootQualibrationModeMono : MonoBehaviour
{
    public bool m_isRecording;
    public List<Vector3> m_pointsEntered;
    
    public void EnterPosition(Vector3 position) {

        if (!m_isRecording) return;
        m_pointsEntered.Add(position);
    }

    [ContextMenu("Start recording")]
    public void StartRecording() {
        m_isRecording = true;
        m_pointsEntered.Clear();
    }
    [ContextMenu("Stop recording")]
    public void StopRecording()
    {
        m_isRecording = false;
    }
}
