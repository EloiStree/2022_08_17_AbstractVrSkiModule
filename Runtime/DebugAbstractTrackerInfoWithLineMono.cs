using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAbstractTrackerInfoWithLineMono : MonoBehaviour
{
    public SkiAbstractTrackerInfoMono m_abstractTracker;


    public void Update()
    {
        Debug.DrawLine(
            m_abstractTracker.m_leftFootTrackerPosition.m_lastReceived,
            m_abstractTracker.m_leftFootTrackerUnorientedRotation.m_lastReceived * Vector3.forward + m_abstractTracker.m_leftFootTrackerPosition.m_lastReceived, Color.cyan, 0.1f);
        Debug.DrawLine(
            m_abstractTracker.m_rightFootTrackerPosition.m_lastReceived,
            m_abstractTracker.m_rightFootTrackerUnorientedRotation.m_lastReceived * Vector3.forward + m_abstractTracker.m_rightFootTrackerPosition.m_lastReceived, Color.cyan*0.95f, 0.1f);
        Debug.DrawLine(
            m_abstractTracker.m_headTrackedWorldPosition.m_lastReceived,
            m_abstractTracker.m_headTrackedWorldRotation.m_lastReceived*Vector3.forward + m_abstractTracker.m_headTrackedWorldPosition.m_lastReceived, Color.white, 0.1f);
    }
}
