using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParalax : MonoBehaviour
{
    public float offsetMul = 1;
    public float smoothTime = .3f;

    private Vector3 startPos;
    private Vector3 velocity;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        offset.z = 0;
        transform.position = Vector3.SmoothDamp(transform.position, startPos + (offset * offsetMul), ref velocity, smoothTime);
    }
}
