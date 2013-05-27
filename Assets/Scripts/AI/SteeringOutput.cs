using UnityEngine;
using System.Collections;
/// <summary>
/// Steering output.
/// </summary>
public struct SteeringOutput
{
/// <summary>
/// The linear vector.
/// </summary>
    public Vector3 linear;

/// <summary>
/// The angular velocity.
/// </summary>
    public float   angular;

    public void Init ()
    {
        linear = Vector3.zero;
        angular = 0.0f;
    }
}
