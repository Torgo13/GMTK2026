using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBullet : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")
            && bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.AddRelativeForce(Vector3.forward * 2, ForceMode.Impulse);
            rb.useGravity = true;
        }
    }
}
