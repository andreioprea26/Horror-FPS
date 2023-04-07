using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    public Camera camera;
    private bool ray_hit_something = false;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        ray_hit_something = Physics.Raycast(ray, out hit);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
    }
}