using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smoothSpeed;
    void Start()
    {
        offset = transform.position - ball.position;
    }

    
    void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position , offset + ball.position , smoothSpeed);
        transform.position = newPos;
    }
}
