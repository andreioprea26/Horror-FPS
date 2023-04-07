using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random; //   |source: https://community.gamedev.tv/t/solved-random-is-an-ambiguous-reference/7440/9

public class weapon_shooting : MonoBehaviour
{
    //deklariere projektil |source: https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    public GameObject projectilePrefab;
    private float projectileSize = 0;
    public Rigidbody rb;
    public float projectileSpeed = 50;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(rb, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
        }
    }
}