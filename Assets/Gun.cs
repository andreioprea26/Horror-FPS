using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float speed = 10f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public GameObject impactEffect, impactEffect2;
    public Transform spawnPoint;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject projectile=Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject projectile2=Instantiate(impactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
            if (TryGetComponent<Animator>(out Animator animator))
            {
                animator.Play("Hit");
            }
        }
    }
}
