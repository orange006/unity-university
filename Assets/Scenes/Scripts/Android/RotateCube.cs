using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    [SerializeField] private float speed = 30f;

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 2 * speed * Time.deltaTime, -speed * Time.deltaTime);
    }
}
