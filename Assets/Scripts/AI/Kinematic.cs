using UnityEngine;
using System.Collections;

/// <summary>
/// Kinematic.
/// </summary>
public struct Kinematic
{
/// <summary>
/// The position.
/// </summary>
    public  Vector3     position;

/// <summary>
/// The velocity.
/// </summary>
    public  Vector3     velocity;

/// <summary>
/// The orientation.
/// </summary>
    public  float       orientation;

/// <summary>
/// The rotation.
/// </summary>
    public  float       rotation;

/// <summary>
/// Init this instance. Pseudo constructor
/// </summary>
    public void Init ()
    {
        position = Vector3.zero;
        velocity = Vector3.zero;
        orientation = 0.0f;
        rotation = 0.0f;
    }

/// <summary>
/// Updates the structure given the steering and time.
/// </summary>
/// <param name='steering'>
/// Steering.
/// </param>
/// <param name='time'>
/// Time. (delta time)
/// </param>
    public void Update (SteeringOutput steering, float time)
    {
        position += velocity;
        orientation += rotation;
        velocity += steering.linear * time;
        rotation += steering.angular * time;
    }

/// <summary>
/// Updates the structure given the steering, max speed and time.
/// </summary>
/// <param name='steering'>
/// Steering.
/// </param>
/// <param name='maxSpeed'>
/// Max speed.
/// </param>
/// <param name='time'>
/// Time.
/// </param>
    public void Update (SteeringOutput steering, float maxSpeed, float time)
    {
        position += velocity;
        orientation += rotation;
        if (velocity.sqrMagnitude > maxSpeed*maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        velocity += steering.linear * time;
        rotation += steering.angular * time;
    }

/// <summary>
/// Gets the new orientation.
/// </summary>
/// <returns>
/// The new orientation.
/// </returns>
/// <param name='currentOrientation'>
/// Current orientation.
/// </param>
/// <param name='velocity'>
/// Velocity.
/// </param>

    public static float GetNewOrientation (float currentOrientation, Vector3 velocity)
    {
        if (velocity.sqrMagnitude > 0.0f)
            return Mathf.Atan2(-velocity.x, velocity.z);
        return currentOrientation;
    }
/// <summary>
/// Gets the orientation as a quaternion.
/// </summary>
/// <returns>
/// The quaternion
/// </returns>
/// <param name='orientation'>
/// Orientation.
/// </param>
    public static Quaternion GetOrientQuat (float orientation)
    {
        Vector3 v = new Vector3(Mathf.Cos(orientation), 0.0f, Mathf.Sin(orientation));
        return Quaternion.LookRotation(v);
    }
}