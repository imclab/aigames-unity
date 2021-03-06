using UnityEngine;
using System.Collections;

public class Player : Agent
{

    private CharacterController m_Controller;
    public override void Awake ()
    {
        base.Awake();
    }


    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        m_Controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public override void Update ()
    {
        Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
        /*if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            m_Steering.linear = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            m_Steering.linear.Normalize();
            m_Steering.linear *= m_MaxSpeed * Time.deltaTime;
            m_Steering.angular = 0.0f;
        }
        else
            m_Steering.linear = m_Kinematic.velocity * -1 * 2.0f;

        m_Steering.angular = 0.0f;
        m_Kinematic.Update(m_Steering, m_MaxSpeed, Time.deltaTime);*/
        //transform.position = m_Kinematic.position;
        //base.Update();

        Vector3 m_Vel = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        m_Vel = m_Vel.normalized * m_MaxSpeed;
        m_Controller.Move(m_Vel * Time.deltaTime);
        if (m_Vel.magnitude != 0.0f)
            transform.rotation = Quaternion.LookRotation(m_Vel);
        m_Kinematic.position = transform.position;
        m_Kinematic.orientation = Mathf.Atan2(transform.forward.z, transform.forward.x);
        m_Kinematic.rotation = 0.0f;
    }

    void OnDrawGizmos ()
    {
        Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
    }
}