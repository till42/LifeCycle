using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRight : MonoBehaviour {

    public float speed;

    public Animator animator;
    public Animator animator2;


    private static int startPosition = 0;
    public static void NextLevel() {
        startPosition = 1;
    }

    public float[] startPositions;

    private Rigidbody m_rigidbody;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody>();
        Vector3 pos = m_rigidbody.position;
        pos.x = startPositions[startPosition];
        m_rigidbody.position = pos;

        animator.gameObject.SetActive(startPosition == 0);
        animator2.gameObject.SetActive(startPosition == 1);

        if (startPosition == 1) {
            speed = -10;
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0) {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            m_rigidbody.velocity = movement * speed;
            if (animator.isActiveAndEnabled)
              animator.SetBool("IsMoving", true);
            if (animator2.isActiveAndEnabled)

                animator2.SetBool("IsMoving", true);

        } else {
            if (animator.isActiveAndEnabled)
                animator.SetBool("IsMoving", false);
            if (animator2.isActiveAndEnabled)
                animator2.SetBool("IsMoving", false);
        }

    }
}
