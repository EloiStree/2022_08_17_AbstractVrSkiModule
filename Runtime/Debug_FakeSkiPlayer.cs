using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_FakeSkiPlayer : MonoBehaviour
{

    public Transform m_whereToMove;
    public Transform m_whatToMove;
    [Range(-1,1)]
    public float m_percentLateral;
    public float m_leftToRightRange = 1;

    [Range(-1,1)]
    public float m_percentVertical;
    public float m_downToTopRange = 1;

    [Range(-1, 1)]
    public float m_percentFrontal;
    public float m_backToFrontRange = 1;


    [Range(-1, 1)]
    public float m_percentTilt;
    public float m_minTiltForward=70;
    public float m_maxTiltBack=60;

    public bool m_useUpdate;
    private void Update()
    {
        if (m_useUpdate)
            Refresh();
    }

    [ContextMenu("Refresh")]
    void Refresh() {
        Vector3 toMove = new Vector3(m_percentLateral * m_leftToRightRange, m_percentVertical * m_downToTopRange, m_percentFrontal * m_backToFrontRange);

        m_whatToMove.position = m_whereToMove.TransformPoint(toMove);

            float tiltValue = 0;
        float angle = 0;
        if (m_percentTilt > 0)
            tiltValue = Mathf.Lerp(0, m_minTiltForward, m_percentTilt);
        else
            tiltValue = Mathf.Lerp(0, -m_maxTiltBack, -m_percentTilt);
        m_whatToMove.rotation = m_whereToMove.rotation * Quaternion.Euler(tiltValue, 0, 0);
    }
}
