using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerModule : MonoBehaviour
{
    internal Action<Collider> TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter(other);
    }
}
