using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyV0_SkitTriPointCalibrationMono : MonoBehaviour
{

    public SkiAbstractTrackerInfoMono m_abstractTrackers;
    public Vector3 m_leftBorder;
    public Vector3 m_rightBorder;
    public Vector3 m_topBorder;

    public Vector3 m_rootCenter;
    public Quaternion m_rootQuaternionDirection;

    public KeyCode m_leftSave= KeyCode.Keypad1;
    public KeyCode m_topSave = KeyCode.Keypad2;
    public KeyCode m_RightSave = KeyCode.Keypad3;

    public void SaveCurrentAsLeft() { m_leftBorder= GetCenterFeet(); }
    public void SaveCurrentAsRight() { 
        m_rightBorder = GetCenterFeet();
    }
    public void SaveCurrentAsTop() {
        m_topBorder = GetCenterFeet();
    }

    public void SaveAsLeft(Vector3 v) { m_leftBorder = v; }
    public void SaveAsRight(Vector3 v) { m_rightBorder = v; }
    public void SaveAsTop(Vector3 v) { m_topBorder = v; }



    public void Update()
    {
        if (Input.GetKeyDown(m_leftSave))
            SaveCurrentAsLeft();
        if (Input.GetKeyDown(m_topSave))
            SaveCurrentAsTop();
        if (Input.GetKeyDown(m_RightSave))
            SaveCurrentAsRight();

        Debug.DrawLine(m_leftBorder, m_rightBorder,Color.green);
        Debug.DrawLine(m_leftBorder, m_topBorder, Color.yellow);
        Debug.DrawLine(m_rightBorder, m_topBorder, Color.yellow);
        Vector3 direction = Vector3.Cross(m_topBorder - m_leftBorder, m_topBorder - m_rightBorder);
        Debug.DrawLine(m_topBorder, m_topBorder+direction*10, Color.red);


        if (m_leftBorder != Vector3.zero && m_rightBorder != Vector3.zero && m_topBorder != Vector3.zero) {

            m_rootCenter = ( m_leftBorder + m_rightBorder )/2f;
            m_rootQuaternionDirection = Quaternion.LookRotation(direction, m_topBorder - m_rootCenter);
            Vector3 currentPosition = GetCenterFeet();
            Vector3 localPosition = Quaternion.Inverse(m_rootQuaternionDirection)*currentPosition - m_rootCenter;
            Debug.DrawLine(Vector3.zero, localPosition , Color.cyan);
             m_radiusHorizontal = 
                Vector3.Distance(m_leftBorder,m_rootCenter);
             m_radiusVertical = 
                Vector3.Distance(m_topBorder, m_rootCenter);
            m_Left2RightPercent = localPosition.x / m_radiusHorizontal;
            m_down2TopPercent = localPosition.y / m_radiusVertical;

//            Debug.DrawLine(m_rootCenter, m_rootCenter +  )

        }

    }
    public float m_radiusHorizontal;
    public float m_radiusVertical;
    private Vector3 GetCenterFeet()
    {
       return (m_abstractTrackers.m_leftFootTrackerPosition.m_lastReceived + m_abstractTrackers.m_rightFootTrackerPosition.m_lastReceived) / 2f;
    }

    public float m_Left2RightPercent;
    public float m_down2TopPercent;

    public Vector3 m_footLeftLocalPosition;
    public Vector3 m_footRightLocalPosition;
    public Vector3 m_headCenterLocalPosition;

    public Vector3 m_footLeftLocalRotation;
    public Vector3 m_footRightLocalRotation;
    public Vector3 m_headCenterLocalRotation;


}
