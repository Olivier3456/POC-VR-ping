using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketBehaviour : MonoBehaviour
{
    [SerializeField] private Transform attachPointTransform;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(attachPointTransform.position);
        rb.MoveRotation(attachPointTransform.rotation);
    }
}
