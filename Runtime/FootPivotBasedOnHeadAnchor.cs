using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPivotBasedOnHeadAnchor : MonoBehaviour
{
    public Transform m_pivotToRotateForwardDirection;
    public Transform m_pivotToRotate;
    public Transform m_targetToFollow;
    public float m_angleOfPlatform;


    public void Update()
    {
        Vector3 localHeadPosition =  m_pivotToRotateForwardDirection.InverseTransformPoint(m_targetToFollow.position);
        m_angleOfPlatform = Vector3.Angle(Vector3.up, localHeadPosition) * Mathf.Sign(localHeadPosition.x);
        m_pivotToRotate.localRotation = Quaternion.Euler(0, 0,- m_angleOfPlatform);
        m_pivotToRotate.position = m_pivotToRotateForwardDirection.position;
    }
}
