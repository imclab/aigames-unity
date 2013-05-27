using UnityEngine;
using System.Collections;

public class KSeek : Behavior
{
    private Kinematic m_Character, m_Target;
    private float m_MaxSpeed;

/// <summary>
/// Set the specified character, target and maxSpeed.
/// </summary>
/// <param name='character'>
/// Character.
/// </param>
/// <param name='target'>
/// Target.
/// </param>
/// <param name='maxSpeed'>
/// Max speed.
/// </param>
    public override void SetKSeek (ref Kinematic character, Kinematic target, float maxSpeed)
    {
        m_Character = character;
        m_Target = target;
        m_MaxSpeed = maxSpeed;
    }

    public override SteeringOutput GetSteering ()
    {
        SteeringOutput steering;
        steering.linear = m_Target.position - m_Character.position;
        steering.linear = steering.linear.normalized * m_MaxSpeed;
        m_Character.orientation = Kinematic.GetNewOrientation(m_Character.orientation, steering.linear);
        steering.angular = 0;
        return steering;
    }
}