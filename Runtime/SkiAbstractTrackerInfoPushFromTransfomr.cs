using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiAbstractTrackerInfoPushFromTransfomr : MonoBehaviour
{

    public SkiAbstractTrackerInfoMono m_skiTracker;
    public Transform m_leftFoot;
    public Transform m_rightFoot;
    public Transform m_headFoot;
   
    void Update()
    {
        m_skiTracker.PushLeftFootPosition(m_leftFoot.position);
        m_skiTracker.PushRightFootPosition(m_rightFoot.position);
        m_skiTracker.PushLeftFootRotation(m_leftFoot.rotation);
        m_skiTracker.PushRightFootRotation(m_rightFoot.rotation);
        m_skiTracker.PushHeadPosition(m_headFoot.position);
        m_skiTracker.PushHeadRotation(m_headFoot.rotation);
    }
}
