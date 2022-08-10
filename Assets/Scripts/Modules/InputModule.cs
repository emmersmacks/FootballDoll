using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyHips;
    [SerializeField] private float _sensetive;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var velocityDirection = Vector3.zero;
            velocityDirection = new Vector3(velocityDirection.x, velocityDirection.y + Input.GetAxis("Mouse Y"), velocityDirection.z + Input.GetAxis("Mouse X"));
            _rigidbodyHips.velocity = velocityDirection * _sensetive;
        }
    }

}
