using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerCntrl : MonoBehaviour
{
    public float speed;
    public Done_Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private Rigidbody m_rigidbody;
    private Animator animator;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        m_rigidbody.velocity = movement * speed;

        m_rigidbody.position = new Vector3
        (
            Mathf.Clamp(m_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(m_rigidbody.position.z, boundary.zMin, boundary.zMax)
        );


        //tell the animator if we are moving
        if (animator != null)
            animator.SetBool("IsMoving", !(moveHorizontal.AlmostEquals(0f) && moveVertical.AlmostEquals(0f)));



    }


}
