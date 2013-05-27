using UnityEngine;
using System.Collections;

public class Behavior
{
    public virtual SteeringOutput GetSteering ()
    {
        SteeringOutput empty = new SteeringOutput();
        empty.Init();
        return empty;
    }

    public virtual void SetKSeek (ref Kinematic character, Kinematic target, float maxSpeed) {}

    public virtual void SetKFlee (ref Kinematic character, Kinematic target, float maxSpeed) {}
}
