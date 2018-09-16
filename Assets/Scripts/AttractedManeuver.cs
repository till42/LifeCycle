using UnityEngine;
using System.Collections;

public class AttractedManeuver : MonoBehaviour {
    public Done_Boundary boundary;
    public float strength;


    private Rigidbody m_rigidbody;
    private Transform target;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody>();

        PlayerCntrl player = FindObjectOfType<PlayerCntrl>();
        if (player != null)
            target = player.transform;
        else
            target = null;
    }




    void FixedUpdate() {
        if (target == null)
            return;

        float newManeuver = (target.position.x - m_rigidbody.position.x) * strength;

        m_rigidbody.velocity = new Vector3(newManeuver, 0.0f, m_rigidbody.velocity.z);

        m_rigidbody.position = new Vector3
        (
            Mathf.Clamp(m_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(m_rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

    }
}
