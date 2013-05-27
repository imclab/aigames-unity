using UnityEngine;
using System.Collections;

public class Follower : Agent
{

    private Behavior    m_KSeek;
    private Kinematic   m_CharKinematic;
	// Use this for initialization
	void Start ()
	{
        m_KSeek = new KSeek();
    }

	// Update is called once per frame
    public override void Update ()
	{
		//Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        m_CharKinematic = player.GetComponent<Agent>().Kinematic;
        m_KSeek.SetKSeek(ref m_Kinematic, m_CharKinematic, m_MaxSpeed);
        m_Steering = m_KSeek.GetSteering();
        m_Kinematic.Update(m_Steering, m_MaxSpeed, Time.deltaTime);
        Debug.Log(m_MaxSpeed);
/*
        // TOMACO
        float avoidDistance = 2f; //0.5f
        float lookAhead = 3f; //2s
        Vector3 rayVector = transform.forward;
        rayVector.Normalize();
        rayVector *= lookAhead;
        RaycastHit hit;
        Debug.DrawRay(transform.position+Vector3.up, transform.forward*lookAhead, Color.cyan);

        LayerMask stuffToCheck = (1 << LayerMask.NameToLayer("Obstacles"));
        if (Physics.Raycast(transform.position, rayVector, out hit, lookAhead, stuffToCheck)) //~LayerMask.NameToLayer("Obstacles")))
        {
            if (hit.collider.tag == "Wall")
            {
                //Debug.Log("BUUU")
                Debug.DrawRay(hit.point, hit.normal*avoidDistance, Color.magenta);
                Vector3 newpos = (hit.point + hit.normal)*avoidDistance - transform.position;
                // TODO:    retrieve the normal, create new target and shit
                //          DO NOT do it for me >_< I just wanna see the f*cking ray
                //          but i'm coding blind. #nowplaying Korn - Blind.
                //Kinematic newtarget = new Kinematic(hit.point+hit.normal * avoidDistance, Vector3.zero, 0, 0);
                //m_Behav = new KSeek(m_Kinematic, newtarget, m_MaxSpeed, npc.transform);
                //SteeringOutput newSteering = m_Behav.GetSteering();
                //m_Steering.m_Linear = newSteering.m_Linear;
                m_Translation += newpos*2f;
            }
        //else
             //Debug.DrawRay(npcPos, rayVector, Color.green);
        }
        else
        {
            //Debug.DrawRay(npcPos, rayVector, Color.magenta);
        }
        // END OF TOMACO
*/

        base.Update ();
	}
	
	void OnDrawGizmos ()
	{
		//Debug.DrawRay(transform.position+Vector3.up, transform.forward*m_DebugRayLenght, m_DebugRayColor);
	}
}
