using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRight : MonoBehaviour {

    public float speed;

    public Animator animator;

    private Rigidbody m_rigidbody;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0) {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            m_rigidbody.velocity = movement * speed;
            animator.SetBool("IsMoving", true);

        } else {
            animator.SetBool("IsMoving", false);
        }

    }
}
