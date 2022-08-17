using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkiAnimationWithFloat : MonoBehaviour
{
    public float m_leftToRightPercent;
    public Animator m_animation;
    public string m_animationName = "Left2Right";
    public void Update()
    {
        SetAnimationPercentLessOneToOne(m_leftToRightPercent);
    }

    private void SetAnimationPercentLessOneToOne(float percent)
    {
        m_leftToRightPercent = percent;
        m_animation.Play(m_animationName, 0, Mathf.Clamp((m_leftToRightPercent+1)/2f,0.001f,0.999f));
        m_animation.speed = 0;
    }

   
}
