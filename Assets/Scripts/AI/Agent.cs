using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour
{
    public      float   m_DebugRayLenght = 1.0f;
    public      Color   m_DebugRayColor = Color.red;
    public      float   m_MaxSpeed = 0.3f;
    protected   Kinematic m_Kinematic;
    protected   SteeringOutput m_Steering;

    public Kinematic Kinematic
    {
        get { return m_Kinematic; }
    }

    public virtual void Awake ()
    {
        
    }

    // Use this for initialization
    public virtual void Start ()
    {
        m_Steering = new SteeringOutput();
        m_Steering.linear = Vector3.zero;
        m_Steering.angular = 0.0f;
        m_Kinematic = new Kinematic();
        m_Kinematic.position = transform.position;
        m_Kinematic.velocity = Vector3.zero;
        m_Kinematic.orientation = 0.0f;
        m_Kinematic.rotation = 0.0f;
    }
    
    // Update is called once per frame
    public virtual void Update ()
    {
        transform.position = m_Kinematic.position;
        transform.rotation = Kinematic.GetOrientQuat(m_Kinematic.orientation);
    }


}
