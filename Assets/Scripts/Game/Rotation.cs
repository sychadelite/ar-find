using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] int _rotationSpeedX;
    [SerializeField] int _rotationSpeedY;
    [SerializeField] int _rotationSpeedZ;

    void Update()
    {
        // Rotation
        transform.Rotate(_rotationSpeedX * Time.deltaTime, _rotationSpeedY * Time.deltaTime, _rotationSpeedZ * Time.deltaTime);
    }
}
