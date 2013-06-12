using UnityEngine;
using System.Collections;

public class Follower : Agent
{

    private Behavior    m_KSeek;
    private Kinematic   m_CharKinematic;
    private GameObject  m_Player;
	// Use this for initialization
	public override void Start ()
	{
        base.Start();
        m_KSeek = new KSeek();
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
    public override void Update ()
	{
		//Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
        m_CharKinematic = m_Player.GetComponent<Agent>().Kinematic;
        m_KSeek.SetKSeek(m_Kinematic, m_CharKinematic, m_MaxSpeed);
        m_Steering = m_KSeek.GetSteering();
        m_Kinematic.Update(m_Steering, m_MaxSpeed, Time.deltaTime);
        //transform.position = m_Kinematic.position;
        //transform.rotation = Kinematic.GetOrientQuat(m_Kinematic.orientation);
        //MetaUpdate();
        base.Update();
        //Vector3 m_Vel = m_Player.transform.position - transform.position;
        //m_Vel = m_Vel.normalized * m_MaxSpeed * Time.deltaTime;
        //transform.Translate(m_Vel, Space.World);
	}
	
	void OnDrawGizmos ()
	{
		//Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
	}
}
