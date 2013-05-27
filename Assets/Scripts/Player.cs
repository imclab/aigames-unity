using UnityEngine;
using System.Collections;

public class Player : Agent
{
    public override void Awake ()
    {
        base.Awake();
    }


    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update ()
    {
        Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            m_Steering.linear = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            m_Steering.linear.Normalize();
            m_Steering.linear *= m_MaxSpeed * Time.deltaTime;
            m_Steering.angular = 0.0f;
        }
        else
            m_Steering.linear = m_Kinematic.velocity * -1 * 2.0f;

        m_Steering.angular = 0.0f;
        m_Kinematic.Update(m_Steering, m_MaxSpeed, Time.deltaTime);
        //transform.position = m_Kinematic.position;
        base.Update();
    }

    void OnDrawGizmos ()
    {
        Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
    }
}