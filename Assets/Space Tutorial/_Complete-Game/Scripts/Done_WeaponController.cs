using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
    private Animator animator;
	void Start ()
	{
        animator = GetComponentInChildren<Animator>();
       
        InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
        if (animator != null)
        {
            animator.SetTrigger("AttackTrigger");
        }
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}
}
