using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vertex : MonoBehaviour {

    /// <summary>
    /// The successors.
    /// </summary>
    public List<GameObject> m_Successors;

    // Use this for initialization
    void Start ()
    {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        foreach (GameObject v in m_Successors)
        {
            if (v != null)
            {
                //Gizmos.DrawRay(v.gameObject.transform.position, gameObject.transform.position);
                Debug.DrawRay(transform.position, v.transform.position, Color.yellow);
            }
        }
    }

    void OnDrawGizmos ()
    {
        // Draw vertices
        Gizmos.color = Color.yellow;
        foreach (GameObject v in m_Successors)
        {
            if (v != null)
            {
                Gizmos.DrawRay(v.transform.position, transform.position);
            }
        }
    }
}
