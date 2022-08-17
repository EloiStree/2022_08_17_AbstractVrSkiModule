using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFakeSkiPlayerWithXboxMono : MonoBehaviour
{

    public Debug_FakeSkiPlayer m_fakeTopPlayer;
    public SetSkiAnimationWithFloat m_fakeFeetPlatformPlayer;


    void Update()
    {
        m_fakeFeetPlatformPlayer.m_leftToRightPercent = Input.GetAxis("Horizontal");
        m_fakeTopPlayer.m_percentLateral= Input.GetAxis("Horizontal")*0.5f;
        m_fakeTopPlayer.m_percentTilt = Input.GetAxis("Vertical");
        m_fakeTopPlayer.m_percentFrontal = Input.GetAxis("Vertical") * 0.5f; 

    }
}
