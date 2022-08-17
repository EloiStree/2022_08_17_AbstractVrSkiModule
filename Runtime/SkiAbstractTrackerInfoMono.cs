using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkiAbstractTrackerInfoMono : MonoBehaviour
{

    public PositionInfoEvent m_leftFootTrackerPosition;
    public RotationInfoEvent m_leftFootTrackerUnorientedRotation;
    public PositionInfoEvent m_rightFootTrackerPosition;
    public RotationInfoEvent m_rightFootTrackerUnorientedRotation;
    public PositionInfoEvent m_headTrackedWorldPosition;

    

    public RotationInfoEvent m_headTrackedWorldRotation;
    [System.Serializable]
    public class PositionInfoEvent : UnityEvent<Vector3> {
        public Vector3 m_lastReceived;
        public void Push(Vector3 position)
        {
            m_lastReceived = position;
            Invoke(position);
        }
    }
    public void PushLeftFootRotation(Quaternion rotation)
    {
        m_leftFootTrackerUnorientedRotation.Push(rotation);
    }
    public void PushRightFootRotation(Quaternion rotation)
    {
        m_rightFootTrackerUnorientedRotation.Push(rotation);
    }

    [System.Serializable]
    public class RotationInfoEvent : UnityEvent<Quaternion>
    {
        public Quaternion m_lastReceived;
        public void Push(Quaternion rotation) {
            m_lastReceived = rotation;
            Invoke(rotation);
        }
    }


    public void PushLeftFootPosition(Vector3 leftFoot) { m_leftFootTrackerPosition.Push(leftFoot); }
    public void PushRightFootPosition(Vector3 rightFoot) { m_rightFootTrackerPosition.Push(rightFoot); }

    public void PushLeftFootUnorientedRotation(Quaternion leftFoot) { m_leftFootTrackerUnorientedRotation.Push(leftFoot); }
    public void PushRightFootUnorientedRotation(Quaternion rightFoot) { m_rightFootTrackerUnorientedRotation.Push(rightFoot); }

    public void PushHeadPosition(Vector3 headWorldPosition) { m_headTrackedWorldPosition.Push(headWorldPosition); }
    public void PushHeadRotation(Quaternion headWorldRotation) { m_headTrackedWorldRotation.Push(headWorldRotation); }

}
