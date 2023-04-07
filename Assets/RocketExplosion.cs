using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public GameObject explosion;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name);
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        Destroy(gameObject);
        Instantiate(explosion, collision.transform);

        if (collision != null)
        {
            collision.gameObject.GetComponent<Target>().TakeDamage(damage);
        }
    }
}
