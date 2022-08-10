using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderModule : MonoBehaviour
{
    public Action<Collision> CollisionEnter = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter(collision);
    }
}
